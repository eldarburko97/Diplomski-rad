namespace eDentalClinic.WinUI.Appointments
{
    partial class frmAppointmentsData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpReservationTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpReservationFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTreatmentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDentistSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDentistName = new System.Windows.Forms.TextBox();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.AppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DentistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DentistSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDate);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpReservationTo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpReservationFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTreatmentName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtClientSurname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClientName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDentistSurname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDentistName);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(223, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 459);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(805, 348);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(164, 21);
            this.checkBoxDate.TabIndex = 15;
            this.checkBoxDate.Text = "Disable the date filter";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(441, 380);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 45);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(718, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Reservation to:";
            // 
            // dtpReservationTo
            // 
            this.dtpReservationTo.Location = new System.Drawing.Point(722, 301);
            this.dtpReservationTo.Name = "dtpReservationTo";
            this.dtpReservationTo.Size = new System.Drawing.Size(247, 22);
            this.dtpReservationTo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Reservation from:";
            // 
            // dtpReservationFrom
            // 
            this.dtpReservationFrom.Location = new System.Drawing.Point(45, 301);
            this.dtpReservationFrom.Name = "dtpReservationFrom";
            this.dtpReservationFrom.Size = new System.Drawing.Size(247, 22);
            this.dtpReservationFrom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Treatment name:";
            // 
            // txtTreatmentName
            // 
            this.txtTreatmentName.Location = new System.Drawing.Point(398, 221);
            this.txtTreatmentName.Name = "txtTreatmentName";
            this.txtTreatmentName.Size = new System.Drawing.Size(240, 22);
            this.txtTreatmentName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(716, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Client surname:";
            // 
            // txtClientSurname
            // 
            this.txtClientSurname.Location = new System.Drawing.Point(719, 133);
            this.txtClientSurname.Name = "txtClientSurname";
            this.txtClientSurname.Size = new System.Drawing.Size(250, 22);
            this.txtClientSurname.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Client name:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(42, 133);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(250, 22);
            this.txtClientName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dentist surname:";
            // 
            // txtDentistSurname
            // 
            this.txtDentistSurname.Location = new System.Drawing.Point(719, 54);
            this.txtDentistSurname.Name = "txtDentistSurname";
            this.txtDentistSurname.Size = new System.Drawing.Size(250, 22);
            this.txtDentistSurname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dentist name:";
            // 
            // txtDentistName
            // 
            this.txtDentistName.Location = new System.Drawing.Point(42, 54);
            this.txtDentistName.Name = "txtDentistName";
            this.txtDentistName.Size = new System.Drawing.Size(250, 22);
            this.txtDentistName.TabIndex = 0;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppointmentID,
            this.DentistName,
            this.DentistSurname,
            this.ClientName,
            this.ClientSurname,
            this.TreatmentName,
            this.Date});
            this.dgvAppointments.Location = new System.Drawing.Point(223, 565);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(1000, 334);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvAppointments_MouseDoubleClick);
            // 
            // AppointmentID
            // 
            this.AppointmentID.DataPropertyName = "AppointmentID";
            this.AppointmentID.HeaderText = "AppointmentID";
            this.AppointmentID.Name = "AppointmentID";
            this.AppointmentID.Visible = false;
            // 
            // DentistName
            // 
            this.DentistName.DataPropertyName = "DentistName";
            this.DentistName.HeaderText = "Dentist name";
            this.DentistName.Name = "DentistName";
            // 
            // DentistSurname
            // 
            this.DentistSurname.DataPropertyName = "DentistSurname";
            this.DentistSurname.HeaderText = "Dentist surname";
            this.DentistSurname.Name = "DentistSurname";
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Client name";
            this.ClientName.Name = "ClientName";
            // 
            // ClientSurname
            // 
            this.ClientSurname.DataPropertyName = "ClientSurname";
            this.ClientSurname.HeaderText = "Client surname";
            this.ClientSurname.Name = "ClientSurname";
            // 
            // TreatmentName
            // 
            this.TreatmentName.DataPropertyName = "TreatmentName";
            this.TreatmentName.HeaderText = "Treatment";
            this.TreatmentName.Name = "TreatmentName";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // frmAppointmentsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1436, 696);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAppointmentsData";
            this.Text = "frmAppointmentsData";
            this.Load += new System.EventHandler(this.FrmAppointmentsData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpReservationTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpReservationFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTreatmentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDentistSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDentistName;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DentistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DentistSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}