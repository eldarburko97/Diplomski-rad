using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class TreatmentAddDTO
    {
        public int TreatmentID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimeRequired { get; set; }
        public IFormFile Image { get; set; }
    }
}
