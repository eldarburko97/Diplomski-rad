using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class AppointmentInsertRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int DentistID { get; set; }
        [Required]
        public int TreatmentID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool? RatingStatus { get; set; }
    }
}
