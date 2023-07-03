namespace Touchdown_Ticketing
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ComboSections = new ComboBox();
            lblSubtotal = new Label();
            ComboRows = new ComboBox();
            BtnCheckPrice = new Button();
            BtnExit = new Button();
            BtnAdmin = new Button();
            ComboDiscounts = new ComboBox();
            ComboSeats = new ComboBox();
            lblDiscount = new Label();
            lblTaxes = new Label();
            lblTotal = new Label();
            lblDiscountPrice = new Label();
            lblTicket = new Label();
            BtnSaveSeat = new Button();
            BtnClear = new Button();
            lblDiscountType = new Label();
            lblAvailable = new Label();
            BtnGetTicket = new Button();
            ComboGameDates = new ComboBox();
            lblGameDate = new Label();
            BtnLayout = new Button();
            SuspendLayout();
            // 
            // ComboSections
            // 
            ComboSections.FormattingEnabled = true;
            ComboSections.Location = new Point(12, 41);
            ComboSections.Name = "ComboSections";
            ComboSections.Size = new Size(136, 23);
            ComboSections.TabIndex = 0;
            ComboSections.SelectedIndexChanged += ComboSections_SelectedIndexChanged;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(154, 161);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(118, 15);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "Subtotal (base ticket)";
            // 
            // ComboRows
            // 
            ComboRows.FormattingEnabled = true;
            ComboRows.ItemHeight = 15;
            ComboRows.Location = new Point(12, 70);
            ComboRows.MaxDropDownItems = 50;
            ComboRows.Name = "ComboRows";
            ComboRows.Size = new Size(136, 23);
            ComboRows.TabIndex = 2;
            ComboRows.SelectedIndexChanged += ComboRows_SelectedIndexChanged;
            // 
            // BtnCheckPrice
            // 
            BtnCheckPrice.Enabled = false;
            BtnCheckPrice.Location = new Point(154, 12);
            BtnCheckPrice.Name = "BtnCheckPrice";
            BtnCheckPrice.Size = new Size(133, 51);
            BtnCheckPrice.TabIndex = 5;
            BtnCheckPrice.Text = "Check Price";
            BtnCheckPrice.UseVisualStyleBackColor = true;
            BtnCheckPrice.Click += BtnCheckPrice_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(432, 68);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(133, 51);
            BtnExit.TabIndex = 9;
            BtnExit.Text = "E&xit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnAdmin
            // 
            BtnAdmin.Location = new Point(432, 12);
            BtnAdmin.Name = "BtnAdmin";
            BtnAdmin.Size = new Size(133, 51);
            BtnAdmin.TabIndex = 10;
            BtnAdmin.Text = "Admin";
            BtnAdmin.UseVisualStyleBackColor = true;
            BtnAdmin.Click += BtnAdmin_Click;
            // 
            // ComboDiscounts
            // 
            ComboDiscounts.FormattingEnabled = true;
            ComboDiscounts.IntegralHeight = false;
            ComboDiscounts.Location = new Point(12, 128);
            ComboDiscounts.Name = "ComboDiscounts";
            ComboDiscounts.Size = new Size(136, 23);
            ComboDiscounts.TabIndex = 11;
            // 
            // ComboSeats
            // 
            ComboSeats.FormattingEnabled = true;
            ComboSeats.Location = new Point(12, 99);
            ComboSeats.Name = "ComboSeats";
            ComboSeats.Size = new Size(136, 23);
            ComboSeats.TabIndex = 12;
            ComboSeats.SelectedIndexChanged += ComboSeats_SelectedIndexChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(154, 191);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(124, 15);
            lblDiscount.TabIndex = 13;
            lblDiscount.Text = "Discount (percentage)";
            // 
            // lblTaxes
            // 
            lblTaxes.AutoSize = true;
            lblTaxes.Location = new Point(154, 221);
            lblTaxes.Name = "lblTaxes";
            lblTaxes.Size = new Size(139, 15);
            lblTaxes.TabIndex = 14;
            lblTaxes.Text = "Taxes (tax rate * subtotal)";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(154, 236);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total";
            // 
            // lblDiscountPrice
            // 
            lblDiscountPrice.AutoSize = true;
            lblDiscountPrice.Location = new Point(154, 206);
            lblDiscountPrice.Name = "lblDiscountPrice";
            lblDiscountPrice.Size = new Size(163, 15);
            lblDiscountPrice.TabIndex = 16;
            lblDiscountPrice.Text = "Discount cost (after discount)";
            // 
            // lblTicket
            // 
            lblTicket.AutoSize = true;
            lblTicket.Location = new Point(154, 262);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(82, 15);
            lblTicket.TabIndex = 17;
            lblTicket.Text = "TicketNumber";
            // 
            // BtnSaveSeat
            // 
            BtnSaveSeat.Enabled = false;
            BtnSaveSeat.Location = new Point(154, 69);
            BtnSaveSeat.Name = "BtnSaveSeat";
            BtnSaveSeat.Size = new Size(133, 51);
            BtnSaveSeat.TabIndex = 18;
            BtnSaveSeat.Text = "Save Seat";
            BtnSaveSeat.UseVisualStyleBackColor = true;
            BtnSaveSeat.Click += BtnSaveSeat_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(293, 12);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(133, 50);
            BtnClear.TabIndex = 19;
            BtnClear.Text = "Clear Fields";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // lblDiscountType
            // 
            lblDiscountType.AutoSize = true;
            lblDiscountType.Location = new Point(154, 176);
            lblDiscountType.Name = "lblDiscountType";
            lblDiscountType.Size = new Size(122, 15);
            lblDiscountType.TabIndex = 20;
            lblDiscountType.Text = "Discount Type (string)";
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Location = new Point(154, 146);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(114, 15);
            lblAvailable.TabIndex = 21;
            lblAvailable.Text = "Availability (Yes/No)";
            // 
            // BtnGetTicket
            // 
            BtnGetTicket.Enabled = false;
            BtnGetTicket.Location = new Point(293, 69);
            BtnGetTicket.Name = "BtnGetTicket";
            BtnGetTicket.Size = new Size(133, 50);
            BtnGetTicket.TabIndex = 19;
            BtnGetTicket.Text = "Show/Hide Ticket";
            BtnGetTicket.UseVisualStyleBackColor = true;
            BtnGetTicket.Click += BtnGetTicket_Click;
            // 
            // ComboGameDates
            // 
            ComboGameDates.FormattingEnabled = true;
            ComboGameDates.Location = new Point(12, 12);
            ComboGameDates.Name = "ComboGameDates";
            ComboGameDates.Size = new Size(136, 23);
            ComboGameDates.TabIndex = 0;
            ComboGameDates.SelectedIndexChanged += ComboGameDates_SelectedIndexChanged;
            // 
            // lblGameDate
            // 
            lblGameDate.AutoSize = true;
            lblGameDate.Location = new Point(154, 131);
            lblGameDate.Name = "lblGameDate";
            lblGameDate.Size = new Size(165, 15);
            lblGameDate.TabIndex = 23;
            lblGameDate.Text = "Game date (Month, Day, Year)";
            // 
            // BtnLayout
            // 
            BtnLayout.Location = new Point(415, 188);
            BtnLayout.Name = "BtnLayout";
            BtnLayout.Size = new Size(133, 51);
            BtnLayout.TabIndex = 24;
            BtnLayout.Text = "Show &Layout";
            BtnLayout.UseVisualStyleBackColor = true;
            BtnLayout.Click += BtnLayout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 379);
            Controls.Add(BtnLayout);
            Controls.Add(lblGameDate);
            Controls.Add(ComboGameDates);
            Controls.Add(lblAvailable);
            Controls.Add(lblDiscountType);
            Controls.Add(BtnGetTicket);
            Controls.Add(BtnClear);
            Controls.Add(BtnSaveSeat);
            Controls.Add(lblTicket);
            Controls.Add(lblDiscountPrice);
            Controls.Add(lblTotal);
            Controls.Add(lblTaxes);
            Controls.Add(lblDiscount);
            Controls.Add(ComboSeats);
            Controls.Add(ComboDiscounts);
            Controls.Add(BtnAdmin);
            Controls.Add(BtnExit);
            Controls.Add(BtnCheckPrice);
            Controls.Add(ComboRows);
            Controls.Add(lblSubtotal);
            Controls.Add(ComboSections);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Touchdown Ticketing | Main";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboSections;
        private Label lblSubtotal;
        private ComboBox ComboRows;
        private Button BtnCheckPrice;
        private Button BtnExit;
        private Button BtnAdmin;
        private ComboBox ComboDiscounts;
        private ComboBox ComboSeats;
        private Label lblDiscount;
        private Label lblTaxes;
        private Label lblTotal;
        private Label lblDiscountPrice;
        private Label lblTicket;
        private Button BtnSaveSeat;
        private Button BtnClear;
        private Label lblDiscountType;
        private Label lblAvailable;
        private Button BtnGetTicket;
        private ComboBox ComboGameDates;
        private Label lblGameDate;
        private Button BtnLayout;
    }
}