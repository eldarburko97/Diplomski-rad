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

namespace eDentalClinic.WinUI.Dentists
{
    public partial class frmDentistsData : Form
    {
        private readonly APIService _dentistService = new APIService("Dentists");
        public frmDentistsData()
        {
            InitializeComponent();
        }

        private async void FrmDentistsData_Load(object sender, EventArgs e)
        {
            var result = await _dentistService.GetAll<List<Model.Dentist>>(null);
            dgvDentistsData.AutoGenerateColumns = false;
            dgvDentistsData.DataSource = result;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new DentistSearchRequest
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };

            var result = await _dentistService.GetAll<List<Model.Dentist>>(search);
            dgvDentistsData.AutoGenerateColumns = false;
            dgvDentistsData.DataSource = result;

            if(result.Count == 0)
            {
                MessageBox.Show("There are not results for this search!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvDentistsData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvDentistsData.SelectedRows[0].Cells[0].Value;
            frmAddDentist frm = new frmAddDentist(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
