using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class PaymentInsertRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int TreatmentID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
