namespace eDentalClinic.WinUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dentistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDentistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestSellingTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dentistsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notificationsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dentistsToolStripMenuItem,
            this.branchesToolStripMenuItem,
            this.treatmentsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.reviewsToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.bestSellingTreatmentToolStripMenuItem,
            this.dentistsReportToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1181, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // dentistsToolStripMenuItem
            // 
            this.dentistsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDentistToolStripMenuItem,
            this.deToolStripMenuItem});
            this.dentistsToolStripMenuItem.Name = "dentistsToolStripMenuItem";
            this.dentistsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.dentistsToolStripMenuItem.Text = "Dentists";
            // 
            // addDentistToolStripMenuItem
            // 
            this.addDentistToolStripMenuItem.Name = "addDentistToolStripMenuItem";
            this.addDentistToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.addDentistToolStripMenuItem.Text = "Add dentist";
            this.addDentistToolStripMenuItem.Click += new System.EventHandler(this.AddDentistToolStripMenuItem_Click);
            // 
            // deToolStripMenuItem
            // 
            this.deToolStripMenuItem.Name = "deToolStripMenuItem";
            this.deToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.deToolStripMenuItem.Text = "Dentist data";
            this.deToolStripMenuItem.Click += new System.EventHandler(this.DeToolStripMenuItem_Click);
            // 
            // branchesToolStripMenuItem
            // 
            this.branchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBranchToolStripMenuItem,
            this.branchDataToolStripMenuItem});
            this.branchesToolStripMenuItem.Name = "branchesToolStripMenuItem";
            this.branchesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.branchesToolStripMenuItem.Text = "Branches";
            // 
            // addBranchToolStripMenuItem
            // 
            this.addBranchToolStripMenuItem.Name = "addBranchToolStripMenuItem";
            this.addBranchToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.addBranchToolStripMenuItem.Text = "Add branch";
            this.addBranchToolStripMenuItem.Click += new System.EventHandler(this.AddBranchToolStripMenuItem_Click);
            // 
            // branchDataToolStripMenuItem
            // 
            this.branchDataToolStripMenuItem.Name = "branchDataToolStripMenuItem";
            this.branchDataToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.branchDataToolStripMenuItem.Text = "Branch data";
            this.branchDataToolStripMenuItem.Click += new System.EventHandler(this.BranchDataToolStripMenuItem_Click);
            // 
            // treatmentsToolStripMenuItem
            // 
            this.treatmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTreatmentToolStripMenuItem,
            this.treatmentDataToolStripMenuItem});
            this.treatmentsToolStripMenuItem.Name = "treatmentsToolStripMenuItem";
            this.treatmentsToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.treatmentsToolStripMenuItem.Text = "Treatments";
            // 
            // addTreatmentToolStripMenuItem
            // 
            this.addTreatmentToolStripMenuItem.Name = "addTreatmentToolStripMenuItem";
            this.addTreatmentToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.addTreatmentToolStripMenuItem.Text = "Add treatment";
            this.addTreatmentToolStripMenuItem.Click += new System.EventHandler(this.AddTreatmentToolStripMenuItem_Click);
            // 
            // treatmentDataToolStripMenuItem
            // 
            this.treatmentDataToolStripMenuItem.Name = "treatmentDataToolStripMenuItem";
            this.treatmentDataToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.treatmentDataToolStripMenuItem.Text = "Treatment data";
            this.treatmentDataToolStripMenuItem.Click += new System.EventHandler(this.TreatmentDataToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appointmentsDataToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // appointmentsDataToolStripMenuItem
            // 
            this.appointmentsDataToolStripMenuItem.Name = "appointmentsDataToolStripMenuItem";
            this.appointmentsDataToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.appointmentsDataToolStripMenuItem.Text = "Appointments data";
            this.appointmentsDataToolStripMenuItem.Click += new System.EventHandler(this.AppointmentsDataToolStripMenuItem_Click);
            // 
            // reviewsToolStripMenuItem
            // 
            this.reviewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reviewsDataToolStripMenuItem});
            this.reviewsToolStripMenuItem.Name = "reviewsToolStripMenuItem";
            this.reviewsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.reviewsToolStripMenuItem.Text = "Reviews";
            // 
            // reviewsDataToolStripMenuItem
            // 
            this.reviewsDataToolStripMenuItem.Name = "reviewsDataToolStripMenuItem";
            this.reviewsDataToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.reviewsDataToolStripMenuItem.Text = "Reviews data";
            this.reviewsDataToolStripMenuItem.Click += new System.EventHandler(this.ReviewsDataToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsDataToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.clientToolStripMenuItem.Text = "Clients";
            // 
            // clientsDataToolStripMenuItem
            // 
            this.clientsDataToolStripMenuItem.Name = "clientsDataToolStripMenuItem";
            this.clientsDataToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.clientsDataToolStripMenuItem.Text = "Clients data";
            this.clientsDataToolStripMenuItem.Click += new System.EventHandler(this.ClientsDataToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsDataToolStripMenuItem,
            this.addPaymentToolStripMenuItem});
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // paymentsDataToolStripMenuItem
            // 
            this.paymentsDataToolStripMenuItem.Name = "paymentsDataToolStripMenuItem";
            this.paymentsDataToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.paymentsDataToolStripMenuItem.Text = "Payments data";
            this.paymentsDataToolStripMenuItem.Click += new System.EventHandler(this.PaymentsDataToolStripMenuItem_Click);
            // 
            // addPaymentToolStripMenuItem
            // 
            this.addPaymentToolStripMenuItem.Name = "addPaymentToolStripMenuItem";
            this.addPaymentToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addPaymentToolStripMenuItem.Text = "Add payment";
            this.addPaymentToolStripMenuItem.Click += new System.EventHandler(this.AddPaymentToolStripMenuItem_Click);
            // 
            // bestSellingTreatmentToolStripMenuItem
            // 
            this.bestSellingTreatmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newReportToolStripMenuItem});
            this.bestSellingTreatmentToolStripMenuItem.Name = "bestSellingTreatmentToolStripMenuItem";
            this.bestSellingTreatmentToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.bestSellingTreatmentToolStripMenuItem.Text = "Treatments report";
            // 
            // newReportToolStripMenuItem
            // 
            this.newReportToolStripMenuItem.Name = "newReportToolStripMenuItem";
            this.newReportToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.newReportToolStripMenuItem.Text = "New report";
            this.newReportToolStripMenuItem.Click += new System.EventHandler(this.NewReportToolStripMenuItem_Click);
            // 
            // dentistsReportToolStripMenuItem
            // 
            this.dentistsReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newReportToolStripMenuItem1});
            this.dentistsReportToolStripMenuItem.Name = "dentistsReportToolStripMenuItem";
            this.dentistsReportToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.dentistsReportToolStripMenuItem.Text = "Dentists report";
            // 
            // newReportToolStripMenuItem1
            // 
            this.newReportToolStripMenuItem1.Name = "newReportToolStripMenuItem1";
            this.newReportToolStripMenuItem1.Size = new System.Drawing.Size(159, 26);
            this.newReportToolStripMenuItem1.Text = "New report";
            this.newReportToolStripMenuItem1.Click += new System.EventHandler(this.NewReportToolStripMenuItem1_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNotificationToolStripMenuItem,
            this.notificationsDataToolStripMenuItem});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // addNotificationToolStripMenuItem
            // 
            this.addNotificationToolStripMenuItem.Name = "addNotificationToolStripMenuItem";
            this.addNotificationToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addNotificationToolStripMenuItem.Text = "Add notification";
            this.addNotificationToolStripMenuItem.Click += new System.EventHandler(this.AddNotificationToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 533);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1181, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // notificationsDataToolStripMenuItem
            // 
            this.notificationsDataToolStripMenuItem.Name = "notificationsDataToolStripMenuItem";
            this.notificationsDataToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.notificationsDataToolStripMenuItem.Text = "Notifications data";
            this.notificationsDataToolStripMenuItem.Click += new System.EventHandler(this.NotificationsDataToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 558);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem dentistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDentistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTreatmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestSellingTreatmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dentistsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsDataToolStripMenuItem;
    }
}



