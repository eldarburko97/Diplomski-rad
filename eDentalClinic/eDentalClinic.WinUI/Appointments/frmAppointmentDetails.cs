using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Appointments
{
    public partial class frmAppointmentDetails : Form
    {
        private readonly APIService _appointmentService = new APIService("Appointments");
        private int? _id = null;
        public frmAppointmentDetails(int? id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void FrmAppointmentDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var appointment = await _appointmentService.GetById<Appointment>(_id);
                txtClientName.Text = appointment.User.FirstName;
                txtClientSurname.Text = appointment.User.LastName;
                txtTreatmentName.Text = appointment.Treatment.Name;
                txtPrice.Text = appointment.Treatment.Price.ToString();
                txtDentistName.Text = appointment.Dentist.FirstName;
                txtDentistSurname.Text = appointment.Dentist.LastName;
                txtStartDate.Text = appointment.StartDate.ToString("MM/dd/yyyy HH:mm");
                txtEndDate.Text = appointment.EndDate.ToString("MM/dd/yyyy HH:mm");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
