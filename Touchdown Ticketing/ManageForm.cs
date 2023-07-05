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
            // Getting the MS SQL connection string from public class 'Constants'.
            string dateConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection dateConnection = new(dateConnectionString);

            // Defining the SQL query to retrieve the distinct 'GameDate' values from the
            // 'Stadium' table in ascending order.
            string dateQuery = "SELECT DISTINCT GameDate FROM Stadium ORDER BY GameDate ASC";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand dateCommand = new(dateQuery, dateConnection);

            try
            {
                // Opening the connection to the database.
                dateConnection.Open();

                // Executing the SQL query and retrieving the results.
                using SqlDataReader dateReader = dateCommand.ExecuteReader();

                // Iterating through the result set.
                while (dateReader.Read())
                {
                    // Formatting the date values then adding them to the combo box 'ComboDateUpdate'
                    // dropdown.
                    DateTime gameDate = dateReader.GetDateTime(0);
                    string formattedDate = gameDate.ToString("MMM dd, yyyy");
                    ComboDateUpdate.Items.Add(formattedDate);
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message, "Populate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message, "Populate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Displaying an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message, "Populate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Displaying an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message, "Populate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearDataIndexChange(string comboTypeName)
        {
            // Storing the type of the combo box as string clearDataString.
            string clearDataString = comboTypeName;

            // Checking the clearDataString value to determine which displayed data to clear.
            if (clearDataString == "Game")
            {
                // Clearing the combo boxes 'ComboSectionUpdate', 'CombowRowUpdate',
                // and 'ComboSeatUpdate' of their respective text and items.
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
            else if (clearDataString == "Section")
            {
                // Clearing the combo boxes 'CombowRowUpdate' and 'ComboSeatUpdate'
                // of their respective text and items.
                ComboRowUpdate.Text = string.Empty;
                ComboRowUpdate.Items.Clear();
                ComboRowUpdate.SelectedItem = null;
                ComboSeatUpdate.Text = string.Empty;
                ComboSeatUpdate.Items.Clear();
                ComboSeatUpdate.SelectedItem = null;
            }
            else if (clearDataString == "Row")
            {
                // Clearing the combo box 'ComboSeatUpdate' its text and items.
                ComboSeatUpdate.Text = string.Empty;
                ComboSeatUpdate.Items.Clear();
                ComboSeatUpdate.SelectedItem = null;
            }
        }

        private static void UpdateSeatData(DateTime seatDay, string seatSection, string seatRow, string seatNumber)
        {
            // Getting the MS SQL connection string from public class 'Constants'.
            string updateSeatConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection updateSeatConnection = new(updateSeatConnectionString);

            // Defining the SQL query to update the seat availability and ticket type in the 'Stadium' table
            // respective of the game date, section, row, and seat.
            string updateSeatQuery = "UPDATE Stadium SET Availability = 1, TicketType = 'Not Sold' WHERE GameDate = @GameDate AND Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand updateSeatCommand = new(updateSeatQuery, updateSeatConnection);

            // Setting the paramater values for the query (game date, section, row, and seat).
            updateSeatCommand.Parameters.AddWithValue("@GameDate", seatDay);
            updateSeatCommand.Parameters.AddWithValue("@Section", seatSection);
            updateSeatCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            updateSeatCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);

            try
            {
                // Opening the connection to the database.
                updateSeatConnection.Open();

                // Executing the SQL query and retrieving the results.
                updateSeatCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message, "Populate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool CheckAvailability(DateTime seatDay, string seatSection, string seatRow, string seatNumber)
        {
            // Getting the MS SQL connection string from public class 'Constants'.
            string seatAvailableConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection seatAvailableConnection = new(seatAvailableConnectionString);

            // Defining the SQL query to retrieve availability of a seat from the 'Stadium' table
            // respective of the game date, section, row, and seat.
            string seatAvailableQuery = "SELECT Availability FROM Stadium WHERE Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber AND GameDate = @GameDate";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand seatAvailableCommand = new(seatAvailableQuery, seatAvailableConnection);

            // Setting the paramater values for the query (game date, section, row, and seat).
            seatAvailableCommand.Parameters.AddWithValue("@Section", seatSection);
            seatAvailableCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            seatAvailableCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);
            seatAvailableCommand.Parameters.AddWithValue("@GameDate", seatDay);

            // Opening the connection to the database.
            seatAvailableConnection.Open();

            // Executing the SQL query and retrieving the results.
            object seatAvailableResult = seatAvailableCommand.ExecuteScalar();

            // Checking if the seat availability result is not null, not DBNull.Value, and of type bool.
            if (seatAvailableResult != null && seatAvailableResult != DBNull.Value && seatAvailableResult is bool isAvailable)
            {
                // Returning the value indicating the seat availability.
                return isAvailable;
            }
            else
            {
                // Throwing an exception if an error is encountered.
                throw new Exception("Seat availability could not be determined for the specified parameters.");
            }
        }

        private void ComboDateUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Game" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Game");
            // Calling the method 'PopulateSectionsDropdown()' to populate the combo box
            // 'ComboSectionUpdate'.
            PopulateSectionsDropdown();
        }

        private void ComboSectionUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Section" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Section");
            // Calling the method 'PopulateRowsDropdown()' to populate the combo box
            // 'ComboRowUpdate'.
            PopulateRowsDropdown();
        }

        private void ComboRowUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Row" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Row");
            // Calling the method 'PopulateRowsDropdown()' to populate the combo box
            // 'ComboSeatUpdate'.
            PopulateSeatsDropdown();
        }

        private void BtnReleaseSeat_Click(object sender, EventArgs e)
        {
            // Ensuring that a section, row, seat, and date have been selected.
            // Additionally parsing the date.
            if (ComboSectionUpdate.SelectedItem is string selectedSection &&
                ComboRowUpdate.SelectedItem is string selectedRow &&
                ComboSeatUpdate.SelectedItem is string selectedSeat &&
                ComboDateUpdate.SelectedItem is string selectedDateStr &&
                DateTime.TryParse(selectedDateStr, out DateTime selectedDate))
            {
                // Checking seat availability.
                bool isAvailable = CheckAvailability(selectedDate, selectedSection, selectedRow, selectedSeat);

                // Decision statement based on specified seat availability.
                if (isAvailable)
                {
                    // Informative message box if the seat has not been reserved.
                    MessageBox.Show("Seat has not been reserved.", "Touchdown Ticketing | Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Releasing the seat.
                    UpdateSeatData(selectedDate, selectedSection, selectedRow, selectedSeat);
                    MessageBox.Show("Seat released successfully.", "Touchdown Ticketing | Release Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Displaying an error message if needed.
                MessageBox.Show("Invalid selection or missing data.", "Touchdown Ticketing | Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReleaseAll_Click(object sender, EventArgs e)
        {
            // Getting the MS SQL connection string from public class 'Constants'.
            string releaseConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection releaseConnection = new(releaseConnectionString);

            // Defining the SQL query to update the seat availability and ticket type in the 'Stadium' table
            // for all the seats that are reserved.
            string releaseQuery = "UPDATE Stadium SET Availability = 1, TicketType = 'Not Sold' WHERE Availability = 0";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand releaseCommand = new(releaseQuery, releaseConnection);

            try
            {
                // Opening the connection to the database.
                releaseConnection.Open();

                // Executing the SQL query and retrieving the results.
                int releaseSeatsAffected = releaseCommand.ExecuteNonQuery();

                // Decision statement based on executed query result.
                if (releaseSeatsAffected > 0)
                {
                    // Displaying the number of seats updated.
                    MessageBox.Show($"Updated {releaseSeatsAffected} seats.", "Release Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Displaying informative message if no seats can be released.
                    MessageBox.Show("Error: All seats are currently available.", "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message, "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            // Getting the MS SQL connection string from public class 'Constants'.
            string reportConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection reportConnection = new(reportConnectionString);

            // Defining the SQL query to retrieve the number of tickets sold for each game day,
            // grouped by the ticket type.
            string reportQuery = "SELECT GameDate, TicketType, COUNT(*) AS TotalCount FROM Stadium GROUP BY GameDate, TicketType ORDER BY GameDate, TicketType";

            // Creating a new SqlCommand using the query and connection.
            using SqlCommand reportCommand = new(reportQuery, reportConnection);

            try
            {
                // Opening the connection to the database.
                reportConnection.Open();

                // Executing the SQL query and retrieving the results.
                using SqlDataReader reportReader = reportCommand.ExecuteReader();

                // Creating a new instance of StringBuilder 'reportBuilder'.
                StringBuilder reportBuilder = new();

                // Iterating through the results.
                while (reportReader.Read())
                {
                    // Retrieving the game date, ticket type, and total count from the results.
                    DateTime gameDate = Convert.ToDateTime(reportReader["GameDate"]);
                    string? ticketType = reportReader["TicketType"].ToString();
                    int totalCount = Convert.ToInt32(reportReader["TotalCount"]);

                    // Appending the information to the report string builder.
                    reportBuilder.AppendLine($"Date: {gameDate.ToShortDateString()} | Ticket Type: {ticketType} | Total Count: {totalCount}");
                }

                // Converting the report string builder to a string and displaying it.
                string report = reportBuilder.ToString();
                MessageBox.Show(report, "Touchdown Ticketing | Ticket Sales Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error retrieving ticket sales data: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Showing the main form.
            mainForm.Show();
            // Closing the current form.
            this.Close();
        }
    }
}