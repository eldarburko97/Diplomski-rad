using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimeRequired { get; set; }
        public byte[] Image { get; set; }

        // public virtual ICollection<DentistTreatmentType> DentistTreatmentTypes { get; set; }
        public virtual ICollection<BranchTreatment> BranchTreatments { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        //public virtual ICollection<Branch> Branches { get; set; }
    }
}
