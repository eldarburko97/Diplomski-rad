using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class RatingSearchRequest
    {
        public int DentistID { get; set; }
        public string DentistName { get; set; }
        public string DentistSurname { get; set; }
    }
}
