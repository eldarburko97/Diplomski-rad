using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class TreatmentSearchRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimeRequired { get; set; }
    }
}
