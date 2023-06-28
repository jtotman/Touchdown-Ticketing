using System.Data.SqlClient;
using System.Text;

namespace Touchdown_Ticketing
{
    public partial class ManageForm : Form
    {
        private readonly MainForm mainForm;

        public ManageForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
            // Calling method 'PopulateGameDayDropdown()' in the ManageForm_Load event.
            PopulateGameDateDropDown();
        }

        private void PopulateGameDateDropDown()
        {
            string dateConnectionString = Constants.ConnectString;

            using SqlConnection dateConnection = new(dateConnectionString);

            string dateQuery = "SELECT DISTINCT GameDate FROM Stadium ORDER BY GameDate ASC";

            using SqlCommand dateCommand = new(dateQuery, dateConnection);

            try
            {
                dateConnection.Open();

                using SqlDataReader dateReader = dateCommand.ExecuteReader();

                while (dateReader.Read())
                {
                    DateTime gameDate = dateReader.GetDateTime(0);
                    string formattedDate = gameDate.ToString("MMM dd, yyyy");
                    ComboDateUpdate.Items.Add(formattedDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateSectionsDropdown()
        {
            // Getting the MS SQL connection string from public class 'Constants'.
            string sectionConnectionString = Constants.ConnectString;

            // Clearing any pre-existing items in the combo-box 'ComboSections' dropdown.
            ComboSectionUpdate.Items.Clear();

            // Creating a new SqlConnection using the connection string.
            using SqlConnection sectionConnection = new(sectionConnectionString);

            // Defining the SQL query to retrieve the distinct 'Section' values from the
            // 'Stadium' table in ascending order.
            string sectionQuery = "SELECT DISTINCT Section FROM Stadium ORDER BY Section ASC";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand sectionCommand = new(sectionQuery, sectionConnection);
            try
            {
                // Opening the connection to the database.
                sectionConnection.Open();

                // Executing the SQL query and retrieving the results.
                using SqlDataReader sectionReader = sectionCommand.ExecuteReader();

                // Iterating through the result set.
                while (sectionReader.Read())
                {
                    // Adding the 'Section' value to the combo box 'ComboSections' dropdown.
                    _ = ComboSectionUpdate.Items.Add(sectionReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateRowsDropdown()
        {
            ComboRowUpdate.Items.Clear();

            // Checking if a section is selected from the combo box 'ComboSections' dropdown.
            if (ComboSectionUpdate.SelectedItem is string selectedSection)
            {
                // Getting the MS SQL connection string from public class 'Constants'.
                string sectionRowsConnectionString = Constants.ConnectString;

                // Creating a new SqlConnection using the connection string.
                using SqlConnection sectionRowsConnection = new(sectionRowsConnectionString);

                // Defining the SQL query to retrieve the count of the distinct number of section rows
                // for the selected section from the 'Stadium' table. 
                string sectionRowsQuery = "SELECT COUNT (DISTINCT SectionRow) FROM Stadium WHERE Section = @Section";

                // Creating a new SqlCommand using the query and connection.
                using SqlCommand sectionRowsCommand = new(sectionRowsQuery, sectionRowsConnection);

                try
                {
                    // Setting the parameter value for the @Section parameter in the query.
                    sectionRowsCommand.Parameters.AddWithValue("@Section", selectedSection);

                    // Opening the connection to the database.
                    sectionRowsConnection.Open();

                    // Executing the query and retrieving the number of distinct section rows.
                    int rowCount = (int)sectionRowsCommand.ExecuteScalar();

                    // Iterating from row number 1 to rowCount (number of all distinct section rows).
                    for (int rowNumber = 1; rowNumber <= rowCount; rowNumber++)
                    {
                        // Converting the row number into a string.
                        string rowNumberStr = rowNumber.ToString();

                        // Adding the distinct 'SectionRow' value to the combo box 'ComboRows' dropdown.
                        ComboRowUpdate.Items.Add(rowNumberStr);
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void PopulateSeatsDropdown()
        {
            // Clearing any pre-existing items in the combo-box 'ComboSeats' dropdown.
            ComboSeatUpdate.Items.Clear();

            // Checking if both a row and a section are selected in the dropdowns of the combo boxes
            // 'ComboRows' and 'ComboSections' respectively
            if (ComboRowUpdate.SelectedItem is string selectedRow && ComboSectionUpdate.SelectedItem is string selectedSection)
            {
                // Getting the MS SQL connection string from public class 'Constants'.
                string seatConnectionString = Constants.ConnectString;

                // Creating a new SqlConnection using the connection string.
                using SqlConnection seatConnection = new(seatConnectionString);

                // Defining the SQL query to retrieve the seat count based on the selected 'SectionRow'
                // and 'Section' values from the 'Stadium' table. 
                string seatQuery = "SELECT COUNT(DISTINCT SeatNumber) FROM Stadium WHERE SectionRow = @SectionRow AND Section = @Section";

                // Creating a new SqlCommand using the query and connection.
                using SqlCommand seatCommand = new(seatQuery, seatConnection);

                try
                {
                    // Setting the paramater values for the query (row and section).
                    seatCommand.Parameters.AddWithValue("@SectionRow", selectedRow);
                    seatCommand.Parameters.AddWithValue("@Section", selectedSection);
                    //seatCommand.Parameters.Add("@GameDate", SqlDbType.DateTime).Value = selectedDate;

                    // Opening the connection to the database.
                    seatConnection.Open();

                    // Executing the SQL query and retrieving the results.
                    int seatCount = (int)seatCommand.ExecuteScalar();

                    // Iterating from seat number 1 to seatCount (sum of all seats
                    // in a specific row and section) 
                    for (int seatNumber = 1; seatNumber <= seatCount; seatNumber++)
                    {
                        // Converting the seat number to a string
                        string seatNumStr = seatNumber.ToString();

                        // Adding the 'SeatNumber' value to the combo box 'ComboSeats' dropdown. 
                        ComboSeatUpdate.Items.Add(seatNumStr);
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearDataIndexChange(string comboTypeName)
        {
            string clearString = comboTypeName;

            if (clearString == "Game")
            {
                ComboSectionUpdate.Text = string.Empty;
                ComboSectionUpdate.Items.Clear();
                ComboSectionUpdate.SelectedIndex = -1;
                ComboRowUpdate.Text = string.Empty;
                ComboRowUpdate.Items.Clear();
                ComboRowUpdate.SelectedItem = null;
                ComboSeatUpdate.Text = string.Empty;
                ComboSeatUpdate.Items.Clear();
                ComboSeatUpdate.SelectedItem = null;
            }
            else if (clearString == "Section")
            {
                ComboRowUpdate.Text = string.Empty;
                ComboRowUpdate.Items.Clear();
                ComboRowUpdate.SelectedItem = null;
                ComboSeatUpdate.Text = string.Empty;
                ComboSeatUpdate.Items.Clear();
                ComboSeatUpdate.SelectedItem = null;
            }
            else if (clearString == "Row")
            {
                ComboSeatUpdate.Text = string.Empty;
                ComboSeatUpdate.Items.Clear();
                ComboSeatUpdate.SelectedItem = null;
            }
        }

        private static void UpdateSeatData(DateTime seatDay, string seatSection, string seatRow, string seatNumber)
        {
            string updateSeatConnectionString = Constants.ConnectString;

            using SqlConnection updateSeatConnection = new(updateSeatConnectionString);

            string updateSeatQuery = "UPDATE Stadium SET Availability = 1, TicketType = 'Not Sold' WHERE GameDate = @GameDate AND Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber";

            using SqlCommand updateSeatCommand = new(updateSeatQuery, updateSeatConnection);

            updateSeatCommand.Parameters.AddWithValue("@GameDate", seatDay);
            updateSeatCommand.Parameters.AddWithValue("@Section", seatSection);
            updateSeatCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            updateSeatCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);

            try
            {
                updateSeatConnection.Open();
                updateSeatCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating seat: " + ex.Message);
            }
        }

        private static bool CheckAvailability(DateTime seatDay, string seatSection, string seatRow, string seatNumber)
        {
            string seatAvailableConnectionString = Constants.ConnectString;

            using SqlConnection seatAvailableConnection = new(seatAvailableConnectionString);

            string seatAvailableQuery = "SELECT Availability FROM Stadium WHERE Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber AND GameDate = @GameDate";

            using SqlCommand seatAvailableCommand = new(seatAvailableQuery, seatAvailableConnection);

            seatAvailableCommand.Parameters.AddWithValue("@Section", seatSection);
            seatAvailableCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            seatAvailableCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);
            seatAvailableCommand.Parameters.AddWithValue("@GameDate", seatDay);

            seatAvailableConnection.Open();

            object seatAvailableResult = seatAvailableCommand.ExecuteScalar();
            if (seatAvailableResult != null && seatAvailableResult != DBNull.Value && seatAvailableResult is bool isAvailable)
            {
                return isAvailable;
            }
            else
            {
                throw new Exception("Seat availability could not be determined for the specified parameters.");
            }
        }

        private void ComboDateUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataIndexChange("Game");
            PopulateSectionsDropdown();
        }

        private void ComboSectionUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataIndexChange("Section");
            PopulateRowsDropdown();
        }

        private void ComboRowUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataIndexChange("Row");
            PopulateSeatsDropdown();
        }

        private void BtnReleaseSeat_Click(object sender, EventArgs e)
        {
            if (ComboSectionUpdate.SelectedItem is string selectedSection && ComboRowUpdate.SelectedItem is string selectedRow && ComboSeatUpdate.SelectedItem is string selectedSeat)
            {
                if (ComboDateUpdate.SelectedItem is string selectedDateStr)
                {
                    if (DateTime.TryParse(selectedDateStr, out DateTime selectedDate))
                    {
                        bool isAvailable = CheckAvailability(selectedDate, selectedSection, selectedRow, selectedSeat);
                        if (isAvailable)
                        {
                            MessageBox.Show("Seat has not been reserved.", "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateSeatData(selectedDate, selectedSection, selectedRow, selectedSeat);
                            MessageBox.Show("Seat released successfully.", "Release Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format selected.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No game date selected.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReleaseAll_Click(object sender, EventArgs e)
        {
            string releaseConnectionString = Constants.ConnectString;

            using SqlConnection releaseConnection = new(releaseConnectionString);

            string releaseQuery = "UPDATE Stadium SET Availability = 1, TicketType = 'Not Sold' WHERE Availability = 0";

            using SqlCommand releaseCommand = new(releaseQuery, releaseConnection);

            try
            {
                releaseConnection.Open();
                int releaseSeatsAffected = releaseCommand.ExecuteNonQuery();
                if (releaseSeatsAffected > 0) {
                    MessageBox.Show($"Updated {releaseSeatsAffected} seats.", "Release Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Error: All seats are currently available.", "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            string reportConnectionString = Constants.ConnectString;
            string reportQuery = "SELECT GameDate, TicketType, COUNT(*) AS TotalCount FROM Stadium GROUP BY GameDate, TicketType ORDER BY GameDate, TicketType";

            using SqlConnection reportConnection = new(reportConnectionString);
            using SqlCommand reportCommand = new(reportQuery, reportConnection);

            try
            {
                reportConnection.Open();

                using SqlDataReader reportReader = reportCommand.ExecuteReader();
                StringBuilder reportBuilder = new();

                while (reportReader.Read())
                {
                    DateTime gameDate = Convert.ToDateTime(reportReader["GameDate"]);
                    string? ticketType = reportReader["TicketType"].ToString();
                    int totalCount = Convert.ToInt32(reportReader["TotalCount"]);

                    reportBuilder.AppendLine($"Date: {gameDate.ToShortDateString()} | Ticket Type: {ticketType} | Total Count: {totalCount}");
                }

                string report = reportBuilder.ToString();
                MessageBox.Show(report, "Ticket Sales Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving ticket sales data: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }               

        private void BtnBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}