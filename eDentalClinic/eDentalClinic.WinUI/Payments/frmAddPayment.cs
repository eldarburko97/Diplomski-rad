using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinic.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Payments
{
    public partial class frmAddPayment : Form
    {
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _treatmentService = new APIService("Treatments");
        private readonly APIService _paymentService = new APIService("Payments");
        PaymentInsertRequest request = new PaymentInsertRequest();
        public frmAddPayment()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var client = cmbClients.SelectedItem as frmAddPaymentVM;
                var treatment = cmbTreatments.SelectedItem as Treatment;

                request.UserID = client.UserID;
                request.TreatmentID = treatment.TreatmentID;
                request.Amount = decimal.Parse(txtAmount.Text);
                request.Date = dtpDate.Value.Date;

                await _paymentService.Insert<Payment>(request);
                MessageBox.Show("Payment successfully added !", "Success", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private async Task LoadClients()
        {
            var list = await _userService.GetAll<List<User>>(null);
            List<frmAddPaymentVM> clients = new List<frmAddPaymentVM>();
            foreach (var item in list)
            {
                frmAddPaymentVM client = new frmAddPaymentVM
                {
                    UserID = item.UserID,
                    Client = item.FirstName + " " + item.LastName + " " + "(" + item.Username + ")"
                };
                clients.Add(client);
            }
            clients.Insert(0, new frmAddPaymentVM());
            cmbClients.DisplayMember = "Client";
            cmbClients.ValueMember = "UserID";
            cmbClients.DataSource = clients;
        }

        private async Task LoadTreatments()
        {
            var treatments = await _treatmentService.GetAll<List<Treatment>>(null);
            treatments.Insert(0, new Treatment());
            cmbTreatments.DisplayMember = "Name";
            cmbTreatments.ValueMember = "TreatmentID";
            cmbTreatments.DataSource = treatments;
        }

        private async void FrmAddPayment_Load(object sender, EventArgs e)
        {
            await LoadClients();
            await LoadTreatments();
        }

        private async void CmbTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cmbTreatments.SelectedValue.ToString();
            var id2 = int.Parse(id);
            if (id2 != 0)
            {
                var treatment = await _treatmentService.GetById<Treatment>(id2);
                txtAmount.Text = treatment.Price.ToString();
            }
            else
            {
                txtAmount.Text = "";
            }
        }

        private void CmbClients_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbClients.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(cmbClients, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(cmbClients, null);
            }
        }

        private void CmbTreatments_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTreatments.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(cmbTreatments, Messages.Validation_Field_Required);
            }
            else
            {
                errorProvider.SetError(cmbTreatments, null);
            }
        }

        private void TxtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAmount, Messages.Validation_Field_Required);
            }
            else if (Decimal.TryParse(txtAmount.Text,out decimal result) == false)
            {
                e.Cancel = true;
                errorProvider.SetError(txtAmount, Messages.numeric_err);
            }
            else
            {
                errorProvider.SetError(txtAmount, null);
            }
            
        }
    }
}
