using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class PaymentSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Treatment { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int UserID { get; set; }
    }
}
