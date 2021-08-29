using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
    public class RatingInsertRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int DentistID { get; set; }
        [Required]
        public int DentistRating { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Comment { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
