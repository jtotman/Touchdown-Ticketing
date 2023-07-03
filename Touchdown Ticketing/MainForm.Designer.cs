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
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ComboSections
            // 
            ComboSections.FormattingEnabled = true;
            ComboSections.Location = new Point(6, 89);
            ComboSections.Name = "ComboSections";
            ComboSections.Size = new Size(152, 25);
            ComboSections.TabIndex = 0;
            ComboSections.SelectedIndexChanged += ComboSections_SelectedIndexChanged;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(143, 55);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(130, 17);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "Subtotal (base ticket)";
            // 
            // ComboRows
            // 
            ComboRows.FormattingEnabled = true;
            ComboRows.ItemHeight = 17;
            ComboRows.Location = new Point(6, 137);
            ComboRows.MaxDropDownItems = 50;
            ComboRows.Name = "ComboRows";
            ComboRows.Size = new Size(152, 25);
            ComboRows.TabIndex = 2;
            ComboRows.SelectedIndexChanged += ComboRows_SelectedIndexChanged;
            // 
            // BtnCheckPrice
            // 
            BtnCheckPrice.Enabled = false;
            BtnCheckPrice.Location = new Point(420, 20);
            BtnCheckPrice.Name = "BtnCheckPrice";
            BtnCheckPrice.Size = new Size(133, 51);
            BtnCheckPrice.TabIndex = 5;
            BtnCheckPrice.Text = "Check &Price";
            BtnCheckPrice.UseVisualStyleBackColor = true;
            BtnCheckPrice.Click += BtnCheckPrice_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(554, 228);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(133, 51);
            BtnExit.TabIndex = 9;
            BtnExit.Text = "E&xit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnAdmin
            // 
            BtnAdmin.Location = new Point(554, 143);
            BtnAdmin.Name = "BtnAdmin";
            BtnAdmin.Size = new Size(133, 51);
            BtnAdmin.TabIndex = 10;
            BtnAdmin.Text = "&Admin";
            BtnAdmin.UseVisualStyleBackColor = true;
            BtnAdmin.Click += BtnAdmin_Click;
            // 
            // ComboDiscounts
            // 
            ComboDiscounts.FormattingEnabled = true;
            ComboDiscounts.IntegralHeight = false;
            ComboDiscounts.Location = new Point(6, 233);
            ComboDiscounts.Name = "ComboDiscounts";
            ComboDiscounts.Size = new Size(152, 25);
            ComboDiscounts.TabIndex = 11;
            // 
            // ComboSeats
            // 
            ComboSeats.FormattingEnabled = true;
            ComboSeats.Location = new Point(6, 185);
            ComboSeats.Name = "ComboSeats";
            ComboSeats.Size = new Size(152, 25);
            ComboSeats.TabIndex = 12;
            ComboSeats.SelectedIndexChanged += ComboSeats_SelectedIndexChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(143, 89);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(136, 17);
            lblDiscount.TabIndex = 13;
            lblDiscount.Text = "Discount (percentage)";
            // 
            // lblTaxes
            // 
            lblTaxes.AutoSize = true;
            lblTaxes.Location = new Point(143, 123);
            lblTaxes.Name = "lblTaxes";
            lblTaxes.Size = new Size(156, 17);
            lblTaxes.TabIndex = 14;
            lblTaxes.Text = "Taxes (tax rate * subtotal)";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(143, 140);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 17);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total";
            // 
            // lblDiscountPrice
            // 
            lblDiscountPrice.AutoSize = true;
            lblDiscountPrice.Location = new Point(143, 106);
            lblDiscountPrice.Name = "lblDiscountPrice";
            lblDiscountPrice.Size = new Size(178, 17);
            lblDiscountPrice.TabIndex = 16;
            lblDiscountPrice.Text = "Discount cost (after discount)";
            // 
            // lblTicket
            // 
            lblTicket.Dock = DockStyle.Bottom;
            lblTicket.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTicket.Location = new Point(3, 239);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(225, 25);
            lblTicket.TabIndex = 17;
            lblTicket.Text = "TicketNumber";
            lblTicket.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnSaveSeat
            // 
            BtnSaveSeat.Enabled = false;
            BtnSaveSeat.Location = new Point(554, 20);
            BtnSaveSeat.Name = "BtnSaveSeat";
            BtnSaveSeat.Size = new Size(133, 51);
            BtnSaveSeat.TabIndex = 18;
            BtnSaveSeat.Text = "&Save Seat";
            BtnSaveSeat.UseVisualStyleBackColor = true;
            BtnSaveSeat.Click += BtnSaveSeat_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(420, 143);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(133, 51);
            BtnClear.TabIndex = 19;
            BtnClear.Text = "&Clear Fields";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // lblDiscountType
            // 
            lblDiscountType.AutoSize = true;
            lblDiscountType.Location = new Point(143, 72);
            lblDiscountType.Name = "lblDiscountType";
            lblDiscountType.Size = new Size(134, 17);
            lblDiscountType.TabIndex = 20;
            lblDiscountType.Text = "Discount Type (string)";
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Location = new Point(143, 38);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(123, 17);
            lblAvailable.TabIndex = 21;
            lblAvailable.Text = "Availability (Yes/No)";
            // 
            // BtnGetTicket
            // 
            BtnGetTicket.Enabled = false;
            BtnGetTicket.Location = new Point(554, 81);
            BtnGetTicket.Name = "BtnGetTicket";
            BtnGetTicket.Size = new Size(133, 51);
            BtnGetTicket.TabIndex = 19;
            BtnGetTicket.Text = "Show/Hide &Ticket";
            BtnGetTicket.UseVisualStyleBackColor = true;
            BtnGetTicket.Click += BtnGetTicket_Click;
            // 
            // ComboGameDates
            // 
            ComboGameDates.FormattingEnabled = true;
            ComboGameDates.Location = new Point(6, 41);
            ComboGameDates.Name = "ComboGameDates";
            ComboGameDates.Size = new Size(152, 25);
            ComboGameDates.TabIndex = 0;
            ComboGameDates.SelectedIndexChanged += ComboGameDates_SelectedIndexChanged;
            // 
            // lblGameDate
            // 
            lblGameDate.AutoSize = true;
            lblGameDate.Location = new Point(143, 21);
            lblGameDate.Name = "lblGameDate";
            lblGameDate.Size = new Size(183, 17);
            lblGameDate.TabIndex = 23;
            lblGameDate.Text = "Game date (Month, Day, Year)";
            // 
            // BtnLayout
            // 
            BtnLayout.Location = new Point(420, 81);
            BtnLayout.Name = "BtnLayout";
            BtnLayout.Size = new Size(133, 51);
            BtnLayout.TabIndex = 24;
            BtnLayout.Text = "Show &Layout";
            BtnLayout.UseVisualStyleBackColor = true;
            BtnLayout.Click += BtnLayout_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(ComboGameDates);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ComboSections);
            groupBox1.Controls.Add(ComboRows);
            groupBox1.Controls.Add(ComboSeats);
            groupBox1.Controls.Add(ComboDiscounts);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(165, 267);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = " Seat Selection ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 213);
            label5.Name = "label5";
            label5.Size = new Size(58, 17);
            label5.TabIndex = 0;
            label5.Text = "Discount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 165);
            label4.Name = "label4";
            label4.Size = new Size(33, 17);
            label4.TabIndex = 0;
            label4.Text = "Seat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 117);
            label3.Name = "label3";
            label3.Size = new Size(33, 17);
            label3.TabIndex = 0;
            label3.Text = "Row";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 69);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 0;
            label2.Text = "Section";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(lblGameDate);
            groupBox2.Controls.Add(lblAvailable);
            groupBox2.Controls.Add(lblSubtotal);
            groupBox2.Controls.Add(lblDiscountType);
            groupBox2.Controls.Add(lblDiscount);
            groupBox2.Controls.Add(lblTaxes);
            groupBox2.Controls.Add(lblTotal);
            groupBox2.Controls.Add(lblDiscountPrice);
            groupBox2.Controls.Add(lblTicket);
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(183, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(231, 267);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = " Seat Information ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 140);
            label13.Name = "label13";
            label13.Size = new Size(67, 17);
            label13.TabIndex = 24;
            label13.Text = "Total cost:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 123);
            label12.Name = "label12";
            label12.Size = new Size(43, 17);
            label12.TabIndex = 24;
            label12.Text = "Taxes:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 106);
            label11.Name = "label11";
            label11.Size = new Size(104, 17);
            label11.TabIndex = 24;
            label11.Text = "Discounted cost:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 89);
            label10.Name = "label10";
            label10.Size = new Size(131, 17);
            label10.TabIndex = 24;
            label10.Text = "Discount percentage:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 72);
            label9.Name = "label9";
            label9.Size = new Size(90, 17);
            label9.TabIndex = 24;
            label9.Text = "Discount type:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 55);
            label8.Name = "label8";
            label8.Size = new Size(105, 17);
            label8.TabIndex = 24;
            label8.Text = "Base ticket price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 38);
            label7.Name = "label7";
            label7.Size = new Size(72, 17);
            label7.TabIndex = 24;
            label7.Text = "Availability:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 21);
            label6.Name = "label6";
            label6.Size = new Size(38, 17);
            label6.TabIndex = 24;
            label6.Text = "Date:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 284);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(BtnLayout);
            Controls.Add(BtnGetTicket);
            Controls.Add(BtnClear);
            Controls.Add(BtnSaveSeat);
            Controls.Add(BtnAdmin);
            Controls.Add(BtnExit);
            Controls.Add(BtnCheckPrice);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Touchdown Ticketing | Main";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
    }
}