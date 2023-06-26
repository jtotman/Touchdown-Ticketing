using System;
using System.Data.SqlClient;

namespace Touchdown_Ticketing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }              

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Calling methods 'PopulateGameDayDropdown()' and 'PopulateDiscountDropdown()'
            // in the MainForm_Load event.
            PopulateGameDayDropdown();
            PopulateDiscountDropdown();
        }

        private void ClearFormData()
        {
            // Clearing all the existing and displayed data on the form.

            ComboGameDates.SelectedIndex = 0;
            ComboGameDates.Text = string.Empty;
            ComboSections.SelectedIndex = -1;
            ComboSections.Items.Clear();
            ComboSections.Text = string.Empty;
            ComboRows.SelectedIndex = -1;
            ComboRows.Items.Clear();
            ComboRows.Text = string.Empty;
            ComboSeats.SelectedIndex = -1;
            ComboSeats.Items.Clear();
            ComboSeats.Text = string.Empty;
            ComboDiscounts.SelectedIndex = 0;

            lblGameDate.Text = string.Empty;
            lblAvailable.Text = string.Empty;
            lblSubtotal.Text = string.Empty;
            lblDiscountType.Text = string.Empty;
            lblDiscount.Text = string.Empty;
            lblDiscountPrice.Text = string.Empty;
            lblTaxes.Text = string.Empty;
            lblTotal.Text = string.Empty;
            lblTicket.Text = string.Empty;
        }

        private void PopulateGameDayDropdown()
        {
            // Getting the MS SQL connection string from class 'Constants'.
            string dateConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection dateConnection = new(dateConnectionString);

            // Defining the SQL query to retrieve distinct game dates from the 'Stadium' table
            // and ordering them by ascending order based on GameDate.
            string dateQuery = "SELECT DISTINCT GameDate FROM Stadium ORDER BY GameDate ASC";

            // Creating a new SqlCommand with the query and connection.
            using SqlCommand dateCommand = new(dateQuery, dateConnection);

            try
            {
                // Opening the database connection.
                dateConnection.Open();

                // Executing the SQL command and retrieving the results.
                using SqlDataReader dateReader = dateCommand.ExecuteReader();

                // Iterating over the result set and populating the combo box with formatted dates.
                while (dateReader.Read())
                {
                    // Getting the game date from the result set.
                    DateTime gameDate = dateReader.GetDateTime(0);

                    // Formatting the date as "MMM dd, yyyy" (Jan. 1, 2023).
                    string formattedDate = gameDate.ToString("MMM dd, yyyy");

                    // Adding the formatted dates 'formattedDate to the combo box 'ComboGameDates' dropdown.
                    ComboGameDates.Items.Add(formattedDate);
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateDiscountDropdown()
        {
            // Getting the MS SQL connection string from class 'Constants'.
            string discountConnectionString = Constants.ConnectString;

            // Clearing any pre-existing items in the combo-box 'ComboDiscounts' dropdown.
            ComboDiscounts.Items.Clear();

            // Creating a new SqlConnection using the connection string.
            using SqlConnection discountConnection = new(discountConnectionString);

            // Defining the SQL query to retrieve the values of 'DiscountType' from the
            // 'Discounts' table.
            string discountQuery = "SELECT DiscountType FROM Discounts";

            // Creating a new SqlCommand with the query and connection.
            using SqlCommand discountCommand = new(discountQuery, discountConnection);
            try
            {
                // Opening the database connection.
                discountConnection.Open();

                // Executing the SQL query and retrieving the results.
                using SqlDataReader discountReader = discountCommand.ExecuteReader();

                // Iterating through the result set.
                while (discountReader.Read())
                {
                    // Getting the current value from 'DiscountType'.
                    string discountType = discountReader.GetString(0);

                    // Adding the values of 'DiscountType' to the 'ComboDiscounts' dropdown.
                    ComboDiscounts.Items.Add(discountType);
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message);
            }
            ComboDiscounts.SelectedIndex = 0;
        }

        private void PopulateSectionsDropdown()
        {
            // Getting the MS SQL connection string from class 'Constants'.
            string sectionConnectionString = Constants.ConnectString;

            // Clearing any pre-existing items in the combo-box 'ComboSections' dropdown.
            ComboSections.Items.Clear();

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
                    _ = ComboSections.Items.Add(sectionReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs.
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateRowsDropdown()
        {
            ComboRows.Items.Clear();

            // Checking if a section is selected from the combo box 'ComboSections' dropdown.
            if (ComboSections.SelectedItem is string selectedSection)
            {
                // Getting the MS SQL connection string from class 'Constants'.
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
                        ComboRows.Items.Add(rowNumberStr);
                    }
                }
                catch (Exception ex)
                {
                    // Displaying an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void PopulateSeatsDropdown()
        {
            // Clearing any pre-existing items in the combo-box 'ComboSeats' dropdown.
            ComboSeats.Items.Clear();

            // Checking if both a row and a section are selected in the dropdowns of the combo boxes
            // 'ComboRows' and 'ComboSections' respectively
            if (ComboRows.SelectedItem is string selectedRow && ComboSections.SelectedItem is string selectedSection)
            {
                // Getting the MS SQL connection string from class 'Constants'.
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
                        ComboSeats.Items.Add(seatNumStr);
                    }
                }
                catch (Exception ex)
                {
                    // Displaying an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateBtnCheckPriceEnabledState()
        {
            // Checking if all required selections are made.
            bool isEnabled = ComboGameDates.SelectedItem != null
                && ComboSections.SelectedItem != null
                && ComboRows.SelectedItem != null
                && ComboSeats.SelectedItem != null
                && ComboDiscounts.SelectedItem != null;

            // Enabling or disabling BtnCheckPrice based on the selection state.
            BtnCheckPrice.Enabled = isEnabled;
        }

        private void UpdateBtnSaveSeatEnabledState()
        {
            // Defining the string value to check the label text against.
            string checkAvailable = "Unavailable";

            // Checking if the label text matches the specified value and updating the enabled
            // state of the button 'BtnSaveSeat' accordingly.
            if (lblAvailable.Text == checkAvailable)
            {                
                BtnSaveSeat.Enabled = false;
            }
            else
            {
                BtnSaveSeat.Enabled = true;
            }
        }

        private void ClearDataIndexChange(string comboTypeName)
        {
            // Storing the type of the combo box as string clearDataString.
            string clearDataString = comboTypeName;

            // Disabling the buttons 'BtnCheckPrice' and 'BtnSaveSeat'.
            BtnCheckPrice.Enabled = false;
            BtnSaveSeat.Enabled = false;

            // Clearing the labels related to game data.
            lblGameDate.Text = string.Empty;
            lblAvailable.Text = string.Empty;

            // Clearing the labels related to price calculation.
            lblSubtotal.Text = string.Empty;
            lblDiscountType.Text = string.Empty;
            lblDiscount.Text = string.Empty;
            lblDiscountPrice.Text = string.Empty;
            lblTaxes.Text = string.Empty;
            lblTotal.Text = string.Empty;
            lblTicket.Text = string.Empty;

            // Checking the clearDataString value to determine which displayed data to clear.
            if (clearDataString == "Game")
            {
                // Clearing the combo boxes 'ComboSections', 'ComboRows', and 'ComboSeats'
                // of their respective text and items.
                ComboSections.Text = string.Empty;
                ComboSections.Items.Clear();
                ComboSections.SelectedIndex = -1;                
                ComboRows.Text = string.Empty;
                ComboRows.Items.Clear();
                ComboRows.SelectedItem = null;
                ComboSeats.Text = string.Empty;
                ComboSeats.Items.Clear();
                ComboSeats.SelectedItem = null;
            }
            else if (clearDataString == "Section")
            {
                // Clearing the combo boxes 'ComboRows' and 'ComboSeats'
                // of their respective text and items.
                ComboRows.Text = string.Empty;
                ComboRows.Items.Clear();
                ComboRows.SelectedItem = null;
                ComboSeats.Text = string.Empty;
                ComboSeats.Items.Clear();
                ComboSeats.SelectedItem = null;
            }
            else if (clearDataString == "Row")
            {
                // Clearing the combo box 'ComboSeats' of its text and items.
                ComboSeats.Text = string.Empty;
                ComboSeats.Items.Clear();
                ComboSeats.SelectedItem = null;
            }
            else if (clearDataString == "Seat")
            {
                // Nothing extra needs to be done except for the initial disabling
                // of buttons and clearing of labels.
            }
        }

        private static void UpdateSeatData(DateTime seatDate, string seatSection, string seatRow, string seatNumber, bool newAvailability, string discountType)
        {
            // Getting the SQL connection string from class 'Constants'.
            string updateSeatDataConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection updateSeatDataConnection = new(updateSeatDataConnectionString);

            // Defining the SQL query to update the seat data in the 'Stadium' table for the
            // specified seat.
            string updateSeatDataQuery = "UPDATE Stadium SET Availability = @Availability, TicketType = @TicketType WHERE Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber AND GameDate = @GameDate";

            // Creating a new SqlCommand with the query and connection.
            using SqlCommand updateSeatDataCommand = new(updateSeatDataQuery, updateSeatDataConnection);

            // Setting the parameter values for the SQL query.
            updateSeatDataCommand.Parameters.AddWithValue("@TicketType", discountType);
            updateSeatDataCommand.Parameters.AddWithValue("@Availability", newAvailability);
            updateSeatDataCommand.Parameters.AddWithValue("@GameDate", seatDate);
            updateSeatDataCommand.Parameters.AddWithValue("@Section", seatSection);
            updateSeatDataCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            updateSeatDataCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);

            try
            {
                // Opening the database connection.
                updateSeatDataConnection.Open();
                // Executing the SQL query to update the seat data.
                updateSeatDataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Displaying an error message if an exception occurs during the update.
                MessageBox.Show("Error updating seat data: " + ex.Message);
            }
        }

        private static bool IsSeatAvailable(string seatSection, string seatRow, string seatNumber, DateTime gameDate)
        {
            // Getting the SQL connection string from class 'Constants'.
            string seatAvailableConnectionString = Constants.ConnectString;

            // Creating a new SqlConnection using the connection string.
            using SqlConnection seatAvailableConnection = new(seatAvailableConnectionString);

            // Defining the SQL query to retrieve the availability from the 'Stadium' table
            // for the specified seat.
            string seatAvailableQuery = "SELECT Availability FROM Stadium WHERE Section = @Section AND SectionRow = @SectionRow AND SeatNumber = @SeatNumber AND GameDate = @GameDate";

            // Creating a new SqlCommand with the query and connection.
            using SqlCommand seatAvailableCommand = new(seatAvailableQuery, seatAvailableConnection);

            // Setting the parameter values for the SQL query.
            seatAvailableCommand.Parameters.AddWithValue("@Section", seatSection);
            seatAvailableCommand.Parameters.AddWithValue("@SectionRow", seatRow);
            seatAvailableCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);
            seatAvailableCommand.Parameters.AddWithValue("@GameDate", gameDate);

            // Opening the database connection.
            seatAvailableConnection.Open();

            // Executing the query and retrieving the result as an object using ExecuteScalar().
            object seatAvailableResult = seatAvailableCommand.ExecuteScalar();
            // Checking if the result is not null, not DBNull, and of type bool.
            if (seatAvailableResult != null && seatAvailableResult != DBNull.Value && seatAvailableResult is bool isAvailable)
            {
                // Returning the availability of the seat.
                return isAvailable;
            }
            else
            {
                // Throwing an exception if the seat availability could not be determined.
                throw new Exception("Seat availability could not be determined for the specified parameters.");
            }

        }

        private void ComboGameDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Game" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Game");
            // Calling the method 'PopulateSectionsDropdown()' to populate the combo box
            // 'ComboSections'.
            PopulateSectionsDropdown();
        }

        private void ComboSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Section" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Section");
            // Calling the method 'PopulateRowsDropdown()' to populate the combo box
            // 'ComboRows'.
            PopulateRowsDropdown();
        }

        private void ComboRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Row" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Row");
            // Calling the method 'PopulateSeatsDropdown()' to populate the combo box
            // 'ComboSeats'.
            PopulateSeatsDropdown();
        }

        private void ComboSeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calling the method 'ClearDataIndexChange(string)' with paramater "Seat" for
            // decision statement in method to clear the relevant displayed data.
            ClearDataIndexChange("Seat");
            // Calling the method 'UpdateBtnCheckPriceEnabledState()' to check for and
            // update the enabled state of the Price Check button 'BtnCheckPrice' when the
            // selected index of the combo box 'ComboSeats' is changed.
            UpdateBtnCheckPriceEnabledState();
        }

        private void BtnCheckPrice_Click(object sender, EventArgs e)
        {
            // Checking if a game date is selected in the ComboGameDates dropdown and getting
            // the value as a string.
            if (ComboGameDates.SelectedItem is string selectedDate)
            {
                // Setting the label 'lblGameDate' to display the selected game date.
                lblGameDate.Text = selectedDate;
            }

            // Retrieving the selected values for section, row, seat, and game date as strings.
            // Nullable declaration to ensure that NullExceptions are handled properly.
            string? selectSection = ComboSections.SelectedItem?.ToString();
            string? selectRow = ComboRows.SelectedItem?.ToString();
            string? selectSeat = ComboSeats.SelectedItem?.ToString();
            string? selectDate = ComboGameDates.SelectedItem?.ToString();

            // Parsing the selected game date to DateTime format.
            DateTime gameDate = selectDate != null ? DateTime.Parse(selectDate) : default;

            // Checking the availability of the selected seat for the specified game date.
            bool seatAvailability = IsSeatAvailable(selectSection ?? "", selectRow ?? "", selectSeat ?? "", gameDate);

            // Updating the UI based on seat availability:
            // If the seat is available, the label 'lblAvailable' is updated to display "Available".
            if (seatAvailability)
            {
                lblAvailable.Text = "Available";
            }
            // Else, updating the label 'lblAvailable' to display "Unavailable".
            else
            {
                lblAvailable.Text = "Unavailable";                
            }

            // Updating the enabled state of the button 'BtnSaveSeat'.
            UpdateBtnSaveSeatEnabledState();

            // Checking if a row is selected in the ComboRows dropdown.
            if (ComboRows.SelectedItem is string selectedRow)
            {
                // Getting the MS SQL connection string from class 'Constants'.
                string priceConnectionString = Constants.ConnectString;

                // Creating a new SqlConnection using the connection string.
                using SqlConnection priceConnection = new(priceConnectionString);

                // Defining the SQL query to retrieve 'Price' values from the 'Stadium' table for the selected 'Row'.
                string priceQuery = "SELECT Price FROM Stadium WHERE SectionRow = @Row";

                // Creating a new SqlCommand with the query and connection.
                using SqlCommand priceCommand = new(priceQuery, priceConnection);
                try
                {
                    // Setting the parameter value for the @Row parameter in the query.
                    priceCommand.Parameters.AddWithValue("@Row", selectedRow);

                    // Opening the database connection.
                    priceConnection.Open();

                    // Executing the query and retrieving 'priceResult' using ExecuteScalar().
                    object priceResult = priceCommand.ExecuteScalar();

                    // Checking if 'priceResult' is not null or DBNull.
                    if (priceResult != null && priceResult != DBNull.Value)
                    {
                        // Converting the result to a double value.
                        double basePrice = Convert.ToDouble(priceResult);
                        lblSubtotal.Text = "Base ticket price: $" + basePrice.ToString("N2");

                        // Checking if a discount type is selected in the ComboDiscount dropdown.
                        // Retrieving the discount amount based on the selected discount type.
                        if (ComboDiscounts.SelectedItem is string discountType)
                        {
                            // Getting the MS SQL connection string from class 'Constants'.
                            string discountConnectionString = Constants.ConnectString;

                            // Creating a new SqlConnection using the connection string.
                            using SqlConnection discountConnection = new(discountConnectionString);

                            // Defining the SQL query to retrieve 'DiscountAmount' values from the 'Discounts' table for the selected 'DiscountType'.
                            string discountQuery = "SELECT DiscountAmount FROM Discounts WHERE DiscountType = @DiscountType";

                            // Creating a new SqlCommand with the query and connection.
                            using SqlCommand discountCommand = new(discountQuery, discountConnection);
                            try
                            {
                                // Opening the database connection.
                                discountConnection.Open();

                                // Setting the value of paramater 'DiscountType' with 'discountType'.
                                discountCommand.Parameters.AddWithValue("@DiscountType", discountType);

                                // Executing the SQL query and retrieving the discount amount.
                                object discountResult = discountCommand.ExecuteScalar();

                                // Checking if 'discountResult' is not null and not DBNull.
                                if (discountResult != null && discountResult != DBNull.Value)
                                {
                                    string? discountTypeString;
                                    // Setting double 'discountPercent' to converted value of 'discountResult'.
                                    double discountPercent = Convert.ToDouble(discountResult);

                                    // Checking if discount is applicable and displaying all relevant information.
                                    if (discountPercent != 0.00 && discountPercent > 0.00)
                                    {
                                        // Displaying discount type ("Student", "Veteran", etc).
                                        discountTypeString = ComboDiscounts.SelectedItem.ToString();
                                        lblDiscountType.Text = "Discount type: " + discountTypeString;

                                        // Calculating and displaying the discounted price.
                                        double discountPrice = basePrice * discountPercent;
                                        lblDiscountPrice.Text = "Updated price: $" + discountPrice.ToString("N2");

                                        // Calculating and displaying the percentage with regards to
                                        // a discount type.
                                        discountPercent = (100 - (discountPercent * 100));
                                        lblDiscount.Text = "Discount: " + discountPercent.ToString("N2") + "%";

                                        // Calculating the displaying the cost in taxes.
                                        double taxAmount = discountPrice * Constants.SalesTax;
                                        lblTaxes.Text = "Taxes: $" + taxAmount.ToString("N2");

                                        // Calculating and displaying the total cost of the specific ticket.
                                        double totalPrice = discountPrice + taxAmount;
                                        lblTotal.Text = "Total: $" + totalPrice.ToString("N2");
                                    }
                                    // If discount is not applicable.
                                    else
                                    {
                                        // Displaying the discount type (none/Not Applicable).
                                        discountTypeString = "Discount type: N/A";
                                        lblDiscountType.Text = discountTypeString;

                                        // Displaying the 'discounted' amount to the user (none).
                                        lblDiscountPrice.Text = "Updated price: N/A";
                                        lblDiscount.Text = "Discount: None";

                                        //  Calculating the displaying cost in taxes.
                                        double taxAmount = basePrice * Constants.SalesTax;
                                        lblTaxes.Text = "Taxes: $" + taxAmount.ToString("N2");

                                        // Calculating and displaying the total cost of the specific ticket.
                                        double totalPrice = basePrice + taxAmount;
                                        lblTotal.Text = "Total: $" + totalPrice.ToString("N2");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Displaying an error message if an exception occurs.
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        // If the result is null or DBNull, clearing the label 'lblPrice'.
                        lblSubtotal.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Displaying an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            // Getting the selected section, row, and seat.
            // Nullable declaration to ensure that NullExceptions are handled properly.
            string? ticketSection = ComboSections.SelectedItem?.ToString();
            string? ticketRow = ComboRows.SelectedItem?.ToString()?.PadLeft(3, '0');
            string? ticketSeat = ComboSeats.SelectedItem?.ToString()?.PadLeft(3, '0');

            // Initializing the string 'discountTypeStr' for future using in storing the selected item string.
            string discountTypeStr = "";

            // Checking that a discount type is selected.
            if (ComboDiscounts.SelectedItem is string selectedDiscountType)
            {
                // Checking if the selected discount type is the first option ("No Discount Selected")
                // and assigning "NONE" if so.
                if (ComboDiscounts.SelectedIndex == 0)
                {
                    discountTypeStr = "NONE";
                }
                else
                {
                    // Extracting the first three letters selected discount type and converting them
                    // to uppercase.
                    discountTypeStr = selectedDiscountType[..3].ToUpper();
                }
            }
            // Checking if all necessary selections are made and not null.
            if (ticketSection != null && ticketRow != null && ticketSeat != null)
            {
                // Generating the ticket number based on the section, row, seat number and discount type.
                string ticketNumber = ticketSection + "-" + ticketRow + "-" + ticketSeat + " " + discountTypeStr;
                // Outputting the generated ticket number to label 'lblTicket' and hiding it until the
                // Save Seat button 'BtnSaveSeat' is clicked.
                lblTicket.Text = ticketNumber;
                lblTicket.Visible = false;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Calling the method 'ClearFormData()' when the Clear button 'BtnClear' is clicked.
            ClearFormData();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            // Creating an instance of the 'ManageForm' class 'utilForm' with parameter 'this'
            // to reference the current form.
            ManageForm utilForm = new(this);
            // Displaying the 'ManageForm' instance 'utilForm'.
            utilForm.ShowDialog();
            // Showing the current form ('MainForm') when the user navigates out of/closes the instance
            // of the 'ManageForm' class.
            this.Show();
        }

        private void BtnSaveSeat_Click(object sender, EventArgs e)
        {
            // Getting the selected values 'selectedSection', 'selectedRow', 'selectedSeat', and 'selectedDiscount' as strings from their respective combo box selections.
            if (ComboSections.SelectedItem is string selectedSection && ComboRows.SelectedItem is string selectedRow && ComboSeats.SelectedItem is string selectedSeat && ComboDiscounts.SelectedItem is string selectedDiscount)
            {
                // Checking if the selected discount type is the first option of the dropdown ('No Discount Selected' = 'Standard').
                if (ComboDiscounts.SelectedIndex == 0)
                {
                    selectedDiscount = "Standard";
                }
                // Getting the selected value 'seatDateStr' as a string from the date selection combo box.
                if (ComboGameDates.SelectedItem is string seatDateStr)
                {
                    // Parsing 'seatDateStr' to type DateTime, 'seatDate'.
                    if (DateTime.TryParse(seatDateStr, out DateTime seatDate))
                    {
                        // Setting boolean 'newAvailability' to false for later use in updating seat availability within the database table.
                        bool newAvailability = false;
                        // Calling method 'UpdateSeatData' to update the seat data within the database table with the selected values.
                        UpdateSeatData(seatDate, selectedSection, selectedRow, selectedSeat, newAvailability, selectedDiscount);
                        MessageBox.Show("Seat secured successfully.");
                        lblAvailable.Text = "Unavailable";
                    }                    
                }                
            }
            // Updating the enabled state of the buttons 'BtnSaveSeat' and 'BtnGetTicket'.
            UpdateBtnSaveSeatEnabledState();
            BtnGetTicket.Enabled = true;
        }

        private void BtnGetTicket_Click(object sender, EventArgs e)
        {
            // Toggling the visibility of the label responsible for displaying the ticket number.
            lblTicket.Visible = !lblTicket.Visible;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Button to exit application.
            DialogResult = MessageBox.Show("Are you sure you wish to exit?", "Exit Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Using bool 'DialogResult' to only exit the program if the "Yes" button is clicked.
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}