using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        // public ICollection<DentistBranch> DentistBranches { get; set; }
        public ICollection<Dentist> Dentists { get; set; }
        public  ICollection<BranchTreatment> BranchTreatments { get; set; }
    }
}
