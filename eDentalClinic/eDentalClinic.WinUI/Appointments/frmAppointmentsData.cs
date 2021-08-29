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

namespace eDentalClinic.WinUI.Appointments
{
    public partial class frmAppointmentsData : Form
    {
        private readonly APIService _appointmentService = new APIService("Appointments");
        public frmAppointmentsData()
        {
            InitializeComponent();
        }

        private async void FrmAppointmentsData_Load(object sender, EventArgs e)
        {
            var list = await _appointmentService.GetAll<List<Appointment>>(null);

            List<frmAppointmentsDataVM> AppointmentList = new List<frmAppointmentsDataVM>();

            foreach (var item in list)
            {
                frmAppointmentsDataVM appointment = new frmAppointmentsDataVM
                {
                    AppointmentID = item.AppointmentID,
                    DentistName = item.Dentist.FirstName,
                    DentistSurname = item.Dentist.LastName,
                    ClientName = item.User.FirstName,
                    ClientSurname = item.User.LastName,
                    TreatmentName = item.Treatment.Name,
                    Date = item.StartDate.ToString("MM/dd/yyyy HH:mm")
                };
                AppointmentList.Add(appointment);
            }
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.DataSource = AppointmentList;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            AppointmentSearchRequest request = new AppointmentSearchRequest
            {
                DentistName = txtDentistName.Text,
                DentistSurname = txtDentistSurname.Text,
                ClientName = txtClientName.Text,
                ClientSurname = txtClientSurname.Text,
                TreatmentName = txtTreatmentName.Text
            };

            if (checkBoxDate.Checked)
            {
                request.StartDate = null;
                request.EndDate = null;
            }
            else
            {
                request.StartDate = dtpReservationFrom.Value.Date;
                request.EndDate = dtpReservationTo.Value.Date;
                if(request.EndDate.Value.Date < request.StartDate.Value.Date)
                {
                    MessageBox.Show("Field reservation to must be greater than field reservation from!");
                    return;
                }
            }

            var list = await _appointmentService.GetAll<List<Appointment>>(request);
            List<frmAppointmentsDataVM> AppointmentList = new List<frmAppointmentsDataVM>();
            foreach (var item in list)
            {
                frmAppointmentsDataVM appointment = new frmAppointmentsDataVM
                {
                    AppointmentID = item.AppointmentID,
                    DentistName = item.Dentist.FirstName,
                    DentistSurname = item.Dentist.LastName,
                    ClientName = item.User.FirstName,
                    ClientSurname = item.User.LastName,
                    TreatmentName = item.Treatment.Name,
                    Date = item.StartDate.ToString("MM/dd/yyyy HH:mm")
                };
                AppointmentList.Add(appointment);
            }
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.DataSource = AppointmentList;
            if(AppointmentList.Count == 0)
            {
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvAppointments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvAppointments.SelectedRows[0].Cells[0].Value;
            frmAppointmentDetails frm = new frmAppointmentDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
