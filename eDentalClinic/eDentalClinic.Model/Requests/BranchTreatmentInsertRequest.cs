using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class BranchTreatmentInsertRequest
    {
        [Required]
        public int BranchID { get; set; }
        [Required]
        public int TreatmentID { get; set; }
    }
}
