namespace Touchdown_Ticketing
{
    partial class ManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            BtnBack = new Button();
            ComboSectionUpdate = new ComboBox();
            ComboRowUpdate = new ComboBox();
            ComboSeatUpdate = new ComboBox();
            BtnReleaseAll = new Button();
            BtnReport = new Button();
            BtnReleaseSeat = new Button();
            ComboDateUpdate = new ComboBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(159, 182);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(133, 48);
            BtnBack.TabIndex = 0;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // ComboSectionUpdate
            // 
            ComboSectionUpdate.FormattingEnabled = true;
            ComboSectionUpdate.Location = new Point(12, 89);
            ComboSectionUpdate.Name = "ComboSectionUpdate";
            ComboSectionUpdate.Size = new Size(121, 25);
            ComboSectionUpdate.TabIndex = 1;
            ComboSectionUpdate.SelectedIndexChanged += ComboSectionUpdate_SelectedIndexChanged;
            // 
            // ComboRowUpdate
            // 
            ComboRowUpdate.FormattingEnabled = true;
            ComboRowUpdate.Location = new Point(12, 137);
            ComboRowUpdate.Name = "ComboRowUpdate";
            ComboRowUpdate.Size = new Size(121, 25);
            ComboRowUpdate.TabIndex = 2;
            ComboRowUpdate.SelectedIndexChanged += ComboRowUpdate_SelectedIndexChanged;
            // 
            // ComboSeatUpdate
            // 
            ComboSeatUpdate.FormattingEnabled = true;
            ComboSeatUpdate.Location = new Point(12, 185);
            ComboSeatUpdate.Name = "ComboSeatUpdate";
            ComboSeatUpdate.Size = new Size(121, 25);
            ComboSeatUpdate.TabIndex = 2;
            // 
            // BtnReleaseAll
            // 
            BtnReleaseAll.Location = new Point(159, 74);
            BtnReleaseAll.Name = "BtnReleaseAll";
            BtnReleaseAll.Size = new Size(133, 48);
            BtnReleaseAll.TabIndex = 3;
            BtnReleaseAll.Text = "Release All Seats";
            BtnReleaseAll.UseVisualStyleBackColor = true;
            BtnReleaseAll.Click += BtnReleaseAll_Click;
            // 
            // BtnReport
            // 
            BtnReport.Location = new Point(159, 128);
            BtnReport.Name = "BtnReport";
            BtnReport.Size = new Size(133, 48);
            BtnReport.TabIndex = 4;
            BtnReport.Text = "Generate Report";
            BtnReport.UseVisualStyleBackColor = true;
            BtnReport.Click += BtnReport_Click;
            // 
            // BtnReleaseSeat
            // 
            BtnReleaseSeat.Location = new Point(159, 21);
            BtnReleaseSeat.Name = "BtnReleaseSeat";
            BtnReleaseSeat.Size = new Size(133, 48);
            BtnReleaseSeat.TabIndex = 5;
            BtnReleaseSeat.Text = "Release Seat";
            BtnReleaseSeat.UseVisualStyleBackColor = true;
            BtnReleaseSeat.Click += BtnReleaseSeat_Click;
            // 
            // ComboDateUpdate
            // 
            ComboDateUpdate.FormattingEnabled = true;
            ComboDateUpdate.Location = new Point(12, 41);
            ComboDateUpdate.Name = "ComboDateUpdate";
            ComboDateUpdate.Size = new Size(121, 25);
            ComboDateUpdate.TabIndex = 6;
            ComboDateUpdate.SelectedIndexChanged += ComboDateUpdate_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(ComboDateUpdate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ComboSeatUpdate);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ComboRowUpdate);
            groupBox1.Controls.Add(ComboSectionUpdate);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(141, 218);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = " Seat Update Data ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 0;
            label2.Text = "Section";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(33, 17);
            label3.TabIndex = 0;
            label3.Text = "Row";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 165);
            label4.Name = "label4";
            label4.Size = new Size(33, 17);
            label4.TabIndex = 0;
            label4.Text = "Seat";
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 235);
            Controls.Add(groupBox1);
            Controls.Add(BtnReleaseSeat);
            Controls.Add(BtnReport);
            Controls.Add(BtnReleaseAll);
            Controls.Add(BtnBack);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManageForm";
            Text = "Touchdown Ticketing | Admin Utilities";
            Load += ManageForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnBack;
        private ComboBox ComboSectionUpdate;
        private ComboBox ComboRowUpdate;
        private ComboBox ComboSeatUpdate;
        private Button BtnReleaseAll;
        private Button BtnReport;
        private Button BtnReleaseSeat;
        private ComboBox ComboDateUpdate;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}