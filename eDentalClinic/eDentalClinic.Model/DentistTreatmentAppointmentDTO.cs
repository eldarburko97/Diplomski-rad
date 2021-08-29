using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class DentistTreatmentAppointmentDTO
    {
        public int UserID { get; set; }
        public int DentistID { get; set; }
        public int TreatmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeRequired { get; set; }
    }
}
