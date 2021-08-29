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
    public partial class frmAddBranch : Form
    {
        private readonly APIService _treatmentService = new APIService("Treatments");
        private readonly APIService _branchService = new APIService("Branches");
        private readonly APIService _branchTreatmentService = new APIService("BranchTreatments");
        BranchInsertRequest insertRequest = new BranchInsertRequest();
        public frmAddBranch()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void FrmAddBranch_Load(object sender, EventArgs e)
        {
            var treatments = await _treatmentService.GetAll<List<Treatment>>(null);
            clbTreatments.DataSource = new BindingSource(treatments, null);
            clbTreatments.DisplayMember = "Name";
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                insertRequest.Name = txtName.Text;
                insertRequest.Title = txtTitle.Text;
                var treatments = clbTreatments.CheckedItems.Cast<Model.Treatment>().ToList();
                var result = await _branchService.Insert<Model.Branch>(insertRequest);
                BranchTreatmentInsertRequest insertRequest2 = new BranchTreatmentInsertRequest();
                foreach (var treatment in treatments)
                {
                    insertRequest2.BranchID = result.BranchID;
                    insertRequest2.TreatmentID = treatment.TreatmentID;
                    await _branchTreatmentService.Insert<BranchTreatment>(insertRequest2);
                }
                MessageBox.Show("New branch successfully added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, Messages.Validation_Field_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void TxtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, Messages.Validation_Field_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }

        private void ClbTreatments_Validating(object sender, CancelEventArgs e)
        {
            if (clbTreatments.CheckedItems.Count == 0)
            {
                errorProvider.SetError(clbTreatments, Messages.Validation_Field_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(clbTreatments, null);
            }
        }
    }
}
