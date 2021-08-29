namespace eDentalClinic.WinUI.Dentists
{
    partial class frmDentistsData
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
            this.dgvDentistsData = new System.Windows.Forms.DataGridView();
            this.DentistID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentistsData)).BeginInit();
            this.Filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDentistsData
            // 
            this.dgvDentistsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDentistsData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DentistID,
            this.FirstName,
            this.LastName,
            this.Phone,
            this.Email,
            this.Address,
            this.BirthDate});
            this.dgvDentistsData.Location = new System.Drawing.Point(80, 232);
            this.dgvDentistsData.Name = "dgvDentistsData";
            this.dgvDentistsData.RowTemplate.Height = 24;
            this.dgvDentistsData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDentistsData.Size = new System.Drawing.Size(924, 395);
            this.dgvDentistsData.TabIndex = 0;
            this.dgvDentistsData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvDentistsData_MouseDoubleClick);
            // 
            // DentistID
            // 
            this.DentistID.DataPropertyName = "DentistID";
            this.DentistID.HeaderText = "DentistID";
            this.DentistID.Name = "DentistID";
            this.DentistID.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // BirthDate
            // 
            this.BirthDate.DataPropertyName = "BirthDate";
            this.BirthDate.HeaderText = "Birth date";
            this.BirthDate.Name = "BirthDate";
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.btnSearch);
            this.Filters.Controls.Add(this.txtLastName);
            this.Filters.Controls.Add(this.txtFirstName);
            this.Filters.Controls.Add(this.label2);
            this.Filters.Controls.Add(this.label1);
            this.Filters.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Filters.Location = new System.Drawing.Point(126, 13);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(732, 194);
            this.Filters.TabIndex = 1;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(280, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 34);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(438, 59);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(211, 22);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(36, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(211, 22);
            this.txtFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name:";
            // 
            // frmDentistsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1090, 636);
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.dgvDentistsData);
            this.Name = "frmDentistsData";
            this.Text = "frmDentistsData";
            this.Load += new System.EventHandler(this.FrmDentistsData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentistsData)).EndInit();
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDentistsData;
        private System.Windows.Forms.DataGridViewTextBoxColumn DentistID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}