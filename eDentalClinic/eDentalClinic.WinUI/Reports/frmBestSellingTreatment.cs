using eDentalClinic.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Reports
{
    public partial class frmBestSellingTreatment : Form
    {
        public frmBestSellingTreatment()
        {
            InitializeComponent();
            reportViewer1.ShowExportButton = true;
        }

        private void FrmBestSellingTreatment_Load(object sender, EventArgs e)
        {
            
            this.reportViewer1.RefreshReport();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpDateFrom.Value.Date;
                var endDate = dtpDateTo.Value.Date;
                SqlConnection conn = new SqlConnection("Server=.;Database=eDentalClinic;Trusted_Connection=true;");
                conn.Open();                

                var sqlCode = @"SELECT T.Name AS Treatment, COUNT(T.TreatmentID) AS Number, SUM(T.Price) AS Total
                               FROM Treatments AS T JOIN Appointments AS A
                               ON T.TreatmentID = A.TreatmentID
                               WHERE CAST(A.StartDate AS DATE) >= @startDate AND CAST(A.EndDate AS DATE) <= @endDate
                               GROUP BY T.Name";

                SqlCommand cmd = new SqlCommand(sqlCode, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
               
                SqlDataAdapter das = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet("DataSet1");               
                DataTable resultsTable = new DataTable();
                int a = das.Fill(resultsTable);
                if(a == 0)
                {
                    MessageBox.Show("There are no results for this search !","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
