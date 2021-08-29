using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.ViewModels
{
   public class frmAppointmentsDataVM
    {
        public int AppointmentID { get; set; }
        public string DentistName { get; set; }
        public string DentistSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string TreatmentName { get; set; }
        public string Date { get; set; }
    }
}
