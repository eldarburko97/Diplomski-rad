using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class Rating
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int DentistID { get; set; }
        public int DentistRating { get; set; }
        public string Comment { get; set; }
        public DateTime RatingDate { get; set; }

        public virtual User User { get; set; }
        public virtual Dentist Dentist { get; set; }
    }
}
