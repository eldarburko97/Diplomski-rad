using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        // public int ClientID { get; set; }
        public int UserID { get; set; }
        public int DentistID { get; set; }
        public int TreatmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? RatingStatus { get; set; }
       // public bool? CommentStatus { get; set; }

        // public virtual Client Client { get; set; }
        // public virtual User Dentist { get; set; }
        public virtual User User { get; set; }
        public virtual Dentist Dentist { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
