using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class BranchInsertRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
