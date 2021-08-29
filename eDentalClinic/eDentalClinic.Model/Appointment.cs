using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
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

        public User User { get; set; }
        public Dentist Dentist { get; set; }
        public Treatment Treatment { get; set; }
    }
}
