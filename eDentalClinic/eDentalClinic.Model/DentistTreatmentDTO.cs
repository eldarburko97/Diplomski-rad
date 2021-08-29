using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class DentistTreatmentDTO
    {
        public int DentistID { get; set; }
        public int TreatmentID { get; set; }
        public string Name { get; set; }
        public int TimeRequired { get; set; }
    }
}
