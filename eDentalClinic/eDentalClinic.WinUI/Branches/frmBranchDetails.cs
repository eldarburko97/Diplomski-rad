using eDentalClinic.Model;
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
    public partial class frmBranchDetails : Form
    {
        private readonly APIService _branchService = new APIService("Branches");
        private readonly APIService _branchTreatmentService = new APIService("BranchTreatments");
        private int? _id = null;
        public frmBranchDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmBranchDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var result = await _branchService.GetById<Model.Branch>(_id);
                txtName.Text = result.Name;
                txtTitle.Text = result.Title;

                var list = await _branchTreatmentService.GetAll<List<BranchTreatment>>(new BranchTreatmentSearchRequest { BranchID = result.BranchID });

                foreach (var item in list)
                {
                    listBoxTreatments.Items.Add(item.Treatment.Name);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
