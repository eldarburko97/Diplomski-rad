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

namespace eDentalClinic.WinUI.Branches
{
    public partial class frmBranchesData : Form
    {
        private readonly APIService _branchService = new APIService("Branches");
        public frmBranchesData()
        {
            InitializeComponent();
        }

        private async void FrmBranchesData_Load(object sender, EventArgs e)
        {
            var result = await _branchService.GetAll<List<Model.Branch>>(null);
            dgvBranchesData.AutoGenerateColumns = false;
            dgvBranchesData.DataSource = result;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            BranchSearchRequest request = new BranchSearchRequest
            {
                Name = txtName.Text,
                Title = txtTitle.Text
            };
            var result = await _branchService.GetAll<List<Model.Branch>>(request);
            dgvBranchesData.AutoGenerateColumns = false;
            dgvBranchesData.DataSource = result;
        }

        private void DgvBranchesData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvBranchesData.SelectedRows[0].Cells[0].Value;
            frmBranchDetails frm = new frmBranchDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
