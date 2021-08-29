using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Reports
{
    public partial class frmBusinessReportDentists : Form
    {
        public frmBusinessReportDentists()
        {
            InitializeComponent();
            reportViewer1.ShowExportButton = true;
        }

        private void FrmBusinessReportDentists_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=eDentalClinic;Trusted_Connection=true;");
            conn.Open();

            var sqlCode = @"SELECT D.DentistID, D.FirstName AS Name, D.LastName AS Surname, COUNT(A.AppointmentID) AS Number, SUM(T.Price) AS Total
                               FROM Dentists AS D JOIN Appointments AS A
                               ON D.DentistID = A.DentistID JOIN Treatments AS T
                               ON A.TreatmentID = T.TreatmentID
                               GROUP BY D.DentistID, D.FirstName, D.LastName";

            SqlCommand cmd = new SqlCommand(sqlCode, conn);           
            SqlDataAdapter das = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet("DataSet1");
            DataTable resultsTable = new DataTable();
            int count = das.Fill(resultsTable);
            if (count == 0)
            {
                MessageBox.Show("There are no results for this search !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", resultsTable));
            this.reportViewer1.RefreshReport();
            conn.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text;
                var surname = txtSurname.Text;
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    MessageBox.Show("All fields are required !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                {
                    MessageBox.Show("End date must be greater than start date !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                SqlConnection conn = new SqlConnection("Server=.;Database=eDentalClinic;Trusted_Connection=true;");
                conn.Open();

                var sqlCode = @"SELECT D.DentistID, D.FirstName AS Name, D.LastName AS Surname, COUNT(A.AppointmentID) AS Number, SUM(T.Price) AS Total
                               FROM Dentists AS D JOIN Appointments AS A
                               ON D.DentistID = A.DentistID JOIN Treatments AS T
                               ON A.TreatmentID = T.TreatmentID
                               WHERE D.FirstName = @name AND D.LastName = @surname AND 
                               CAST(A.StartDate AS DATE) >= @startDate AND CAST(A.EndDate AS DATE) <= @endDate
                               GROUP BY D.DentistID, D.FirstName, D.LastName";

                SqlCommand cmd = new SqlCommand(sqlCode, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter das = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet("DataSet1");
                DataTable resultsTable = new DataTable();
                int count = das.Fill(resultsTable);
                if (count == 0)
                {
                    MessageBox.Show("There are no results for this search !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }




                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", resultsTable));
                this.reportViewer1.RefreshReport();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
