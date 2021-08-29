using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.ViewModels
{
   public class frmPaymentsDataVM
    {
        public int PaymentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Treatment { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
    }
}
