using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
    public class TreatmentInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int TimeRequired { get; set; }
        public byte[] Image { get; set; }
    }
}
