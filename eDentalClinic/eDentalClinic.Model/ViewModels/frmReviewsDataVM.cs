using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.ViewModels
{
   public class frmReviewsDataVM
    {
        public int RatingID { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Dentist { get; set; }
        public int RatingValue { get; set; }
    }
}
