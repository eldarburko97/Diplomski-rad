namespace eDentalClinic.WinUI.Reviews
{
    partial class frmReviewsData
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
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.RatingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dentist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDentistName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDentistSurname = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReviews
            // 
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RatingID,
            this.ClientName,
            this.ClientSurname,
            this.Dentist,
            this.RatingValue});
            this.dgvReviews.Location = new System.Drawing.Point(85, 281);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.RowTemplate.Height = 24;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.Size = new System.Drawing.Size(858, 256);
            this.dgvReviews.TabIndex = 0;
            this.dgvReviews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvReviews_MouseDoubleClick);
            // 
            // RatingID
            // 
            this.RatingID.DataPropertyName = "RatingID";
            this.RatingID.HeaderText = "RatingID";
            this.RatingID.Name = "RatingID";
            this.RatingID.Visible = false;
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
            // Dentist
            // 
            this.Dentist.DataPropertyName = "Dentist";
            this.Dentist.HeaderText = "Dentist";
            this.Dentist.Name = "Dentist";
            // 
            // RatingValue
            // 
            this.RatingValue.DataPropertyName = "RatingValue";
            this.RatingValue.HeaderText = "Rating";
            this.RatingValue.Name = "RatingValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dentist name:";
            // 
            // txtDentistName
            // 
            this.txtDentistName.Location = new System.Drawing.Point(110, 65);
            this.txtDentistName.Name = "txtDentistName";
            this.txtDentistName.Size = new System.Drawing.Size(153, 22);
            this.txtDentistName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(623, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dentist surname:";
            // 
            // txtDentistSurname
            // 
            this.txtDentistSurname.Location = new System.Drawing.Point(626, 65);
            this.txtDentistSurname.Name = "txtDentistSurname";
            this.txtDentistSurname.Size = new System.Drawing.Size(153, 22);
            this.txtDentistSurname.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(368, 133);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDentistName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDentistSurname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(85, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 222);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // frmReviewsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1010, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReviews);
            this.Name = "frmReviewsData";
            this.Text = "frmReviewsData";
            this.Load += new System.EventHandler(this.FrmReviewsData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDentistName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDentistSurname;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dentist;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingValue;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}