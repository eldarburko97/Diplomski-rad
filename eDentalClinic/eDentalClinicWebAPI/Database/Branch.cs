using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

          public virtual ICollection<Dentist> Dentists { get; set; }
       // public virtual ICollection<DentistBranch> DentistBranches { get; set; }
        public virtual ICollection<BranchTreatment> BranchTreatments { get; set; }
      //  public virtual ICollection<TreatmentType> TreatmentTypes { get; set; }
    }
}
