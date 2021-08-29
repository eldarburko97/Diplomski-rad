using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class BranchTreatment
    {
        public int BranchTreatmentID { get; set; }
        public int BranchID { get; set; }
        public int TreatmentID { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
