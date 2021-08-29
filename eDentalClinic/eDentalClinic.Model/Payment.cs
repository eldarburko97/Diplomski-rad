using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public int TreatmentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Treatment Treatment { get; set; }
    }
}
