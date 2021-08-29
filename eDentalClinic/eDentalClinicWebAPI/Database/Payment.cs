using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public int TreatmentID { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
