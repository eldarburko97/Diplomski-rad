namespace eDentalClinic.WinUI.Treatments
{
    partial class frmTreatmentsData
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTimeRequired = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTreatmentsData = new System.Windows.Forms.DataGridView();
            this.TreatmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name321 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentsData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudTimeRequired);
            this.groupBox1.Controls.Add(this.nudPrice);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(54, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1320, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(482, 218);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(346, 45);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(985, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time required (hours):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price:";
            // 
            // nudTimeRequired
            // 
            this.nudTimeRequired.Location = new System.Drawing.Point(988, 97);
            this.nudTimeRequired.Name = "nudTimeRequired";
            this.nudTimeRequired.Size = new System.Drawing.Size(271, 22);
            this.nudTimeRequired.TabIndex = 3;
            // 
            // nudPrice
            // 
            this.nudPrice.Location = new System.Drawing.Point(526, 95);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(271, 22);
            this.nudPrice.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 96);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 22);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // dgvTreatmentsData
            // 
            this.dgvTreatmentsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreatmentsData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TreatmentID,
            this.Name321,
            this.Price,
            this.TimeRequired});
            this.dgvTreatmentsData.Location = new System.Drawing.Point(54, 404);
            this.dgvTreatmentsData.Name = "dgvTreatmentsData";
            this.dgvTreatmentsData.RowTemplate.Height = 24;
            this.dgvTreatmentsData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreatmentsData.Size = new System.Drawing.Size(1320, 324);
            this.dgvTreatmentsData.TabIndex = 1;
            this.dgvTreatmentsData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvTreatmentsData_MouseDoubleClick);
            // 
            // TreatmentID
            // 
            this.TreatmentID.DataPropertyName = "TreatmentID";
            this.TreatmentID.HeaderText = "TreatmentID";
            this.TreatmentID.Name = "TreatmentID";
            this.TreatmentID.Visible = false;
            // 
            // Name321
            // 
            this.Name321.DataPropertyName = "Name";
            this.Name321.HeaderText = "Name";
            this.Name321.Name = "Name321";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // TimeRequired
            // 
            this.TimeRequired.DataPropertyName = "TimeRequired";
            this.TimeRequired.HeaderText = "Time required (hours)";
            this.TimeRequired.Name = "TimeRequired";
            // 
            // frmTreatmentsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1416, 756);
            this.Controls.Add(this.dgvTreatmentsData);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTreatmentsData";
            this.Text = "frmTreatmentsData";
            this.Load += new System.EventHandler(this.FrmTreatmentsData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentsData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTimeRequired;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTreatmentsData;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name321;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeRequired;
    }
}