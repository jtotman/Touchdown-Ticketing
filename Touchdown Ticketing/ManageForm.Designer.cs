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
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(271, 72);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(116, 50);
            BtnBack.TabIndex = 0;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // ComboSectionUpdate
            // 
            ComboSectionUpdate.FormattingEnabled = true;
            ComboSectionUpdate.Location = new Point(12, 41);
            ComboSectionUpdate.Name = "ComboSectionUpdate";
            ComboSectionUpdate.Size = new Size(121, 23);
            ComboSectionUpdate.TabIndex = 1;
            ComboSectionUpdate.SelectedIndexChanged += ComboSectionUpdate_SelectedIndexChanged;
            // 
            // ComboRowUpdate
            // 
            ComboRowUpdate.FormattingEnabled = true;
            ComboRowUpdate.Location = new Point(12, 70);
            ComboRowUpdate.Name = "ComboRowUpdate";
            ComboRowUpdate.Size = new Size(121, 23);
            ComboRowUpdate.TabIndex = 2;
            ComboRowUpdate.SelectedIndexChanged += ComboRowUpdate_SelectedIndexChanged;
            // 
            // ComboSeatUpdate
            // 
            ComboSeatUpdate.FormattingEnabled = true;
            ComboSeatUpdate.Location = new Point(12, 99);
            ComboSeatUpdate.Name = "ComboSeatUpdate";
            ComboSeatUpdate.Size = new Size(121, 23);
            ComboSeatUpdate.TabIndex = 2;
            // 
            // BtnReleaseAll
            // 
            BtnReleaseAll.Location = new Point(149, 72);
            BtnReleaseAll.Name = "BtnReleaseAll";
            BtnReleaseAll.Size = new Size(116, 50);
            BtnReleaseAll.TabIndex = 3;
            BtnReleaseAll.Text = "Release All Seats";
            BtnReleaseAll.UseVisualStyleBackColor = true;
            BtnReleaseAll.Click += BtnReleaseAll_Click;
            // 
            // BtnReport
            // 
            BtnReport.Location = new Point(271, 12);
            BtnReport.Name = "BtnReport";
            BtnReport.Size = new Size(116, 50);
            BtnReport.TabIndex = 4;
            BtnReport.Text = "Generate Report";
            BtnReport.UseVisualStyleBackColor = true;
            BtnReport.Click += BtnReport_Click;
            // 
            // BtnReleaseSeat
            // 
            BtnReleaseSeat.Location = new Point(149, 12);
            BtnReleaseSeat.Name = "BtnReleaseSeat";
            BtnReleaseSeat.Size = new Size(116, 50);
            BtnReleaseSeat.TabIndex = 5;
            BtnReleaseSeat.Text = "Release Seat";
            BtnReleaseSeat.UseVisualStyleBackColor = true;
            BtnReleaseSeat.Click += BtnReleaseSeat_Click;
            // 
            // ComboDateUpdate
            // 
            ComboDateUpdate.FormattingEnabled = true;
            ComboDateUpdate.Location = new Point(12, 12);
            ComboDateUpdate.Name = "ComboDateUpdate";
            ComboDateUpdate.Size = new Size(121, 23);
            ComboDateUpdate.TabIndex = 6;
            ComboDateUpdate.SelectedIndexChanged += ComboDateUpdate_SelectedIndexChanged;
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 143);
            Controls.Add(ComboDateUpdate);
            Controls.Add(BtnReleaseSeat);
            Controls.Add(BtnReport);
            Controls.Add(BtnReleaseAll);
            Controls.Add(ComboSeatUpdate);
            Controls.Add(ComboRowUpdate);
            Controls.Add(ComboSectionUpdate);
            Controls.Add(BtnBack);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManageForm";
            Text = "Touchdown Ticketing | Admin Utilities";
            Load += ManageForm_Load;
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
    }
}