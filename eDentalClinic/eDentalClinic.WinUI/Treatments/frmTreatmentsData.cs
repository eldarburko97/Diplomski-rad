using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Treatments
{
    public partial class frmTreatmentsData : Form
    {
        private readonly APIService _treatmentService = new APIService("Treatments");
        public frmTreatmentsData()
        {
            InitializeComponent();
        }

        private async void FrmTreatmentsData_Load(object sender, EventArgs e)
        {
            var result = await _treatmentService.GetAll<List<Model.Treatment>>(null);
            dgvTreatmentsData.AutoGenerateColumns = false;
            dgvTreatmentsData.DataSource = result;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            TreatmentSearchRequest request = new TreatmentSearchRequest
            {
                Name = txtName.Text,
                Price = nudPrice.Value,
                TimeRequired = (int)nudTimeRequired.Value
            };
            var result = await _treatmentService.GetAll<List<Model.Treatment>>(request);
            dgvTreatmentsData.AutoGenerateColumns = false;
            dgvTreatmentsData.DataSource = result;
        }

        private void DgvTreatmentsData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvTreatmentsData.SelectedRows[0].Cells[0].Value;
            frmAddTreatment frm = new frmAddTreatment(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
