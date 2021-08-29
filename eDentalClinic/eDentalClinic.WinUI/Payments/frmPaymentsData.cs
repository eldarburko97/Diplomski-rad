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
    public partial class frmPaymentsData : Form
    {
        private readonly APIService _paymentService = new APIService("Payments");
        public frmPaymentsData()
        {
            InitializeComponent();
        }

        private async void FrmPaymentsData_Load(object sender, EventArgs e)
        {
            var result = await _paymentService.GetAll<List<Payment>>(null);
            List<frmPaymentsDataVM> payments = new List<frmPaymentsDataVM>();
            foreach (var item in result)
            {
                frmPaymentsDataVM payment = new frmPaymentsDataVM
                {
                    PaymentID = item.PaymentID,
                    FirstName = item.User.FirstName,
                    LastName = item.User.LastName,
                    Treatment = item.Treatment.Name,
                    Amount = item.Amount.ToString(),
                    Date = item.Date.ToString("MM/dd/yyyy")
                };
            payments.Add(payment);
            }
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = payments;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            PaymentSearchRequest request = new PaymentSearchRequest
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Treatment = txtTreatment.Text,
            };

            if (checkBoxDate.Checked)
            {
                request.DateFrom = null;
                request.DateTo = null;
            }
            else
            {
                request.DateFrom = dtpFrom.Value.Date;
                request.DateTo = dtpTo.Value.Date;
                if(request.DateTo.Value.Date < request.DateFrom.Value.Date)
                {
                    MessageBox.Show("Date To field must be greater than field Date From");
                    return;
                }
            }

            var result = await _paymentService.GetAll<List<Payment>>(request);
            List<frmPaymentsDataVM> payments = new List<frmPaymentsDataVM>();
            foreach (var item in result)
            {
                frmPaymentsDataVM payment = new frmPaymentsDataVM
                {
                    PaymentID = item.PaymentID,
                    FirstName = item.User.FirstName,
                    LastName = item.User.LastName,
                    Treatment = item.Treatment.Name,
                    Amount = item.Amount.ToString(),
                    Date = item.Date.ToString("MM/dd/yyyy")
                };
                payments.Add(payment);
            }
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = payments;
            if(payments.Count == 0)
            {
                MessageBox.Show("There are not results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
