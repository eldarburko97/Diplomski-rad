using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int DentistID { get; set; }
        public int DentistRating { get; set; }
        [Column(TypeName = "date")]
        public DateTime RatingDate { get; set; }
        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Dentist Dentist { get; set; }
        
    }
}
