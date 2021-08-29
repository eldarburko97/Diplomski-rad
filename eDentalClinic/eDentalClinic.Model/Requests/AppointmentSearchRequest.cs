using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class AppointmentSearchRequest
    {
        public int DentistID { get; set; }
        public int UserID { get; set; }
        public string DentistName { get; set; }
        public string DentistSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string TreatmentName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
