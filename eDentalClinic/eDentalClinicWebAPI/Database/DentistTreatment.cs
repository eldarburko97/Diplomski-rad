using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class DentistTreatment
    {
        public int DentistTreatmentID { get; set; }
        public int DentistID { get; set; }
        public int TreatmentID { get; set; }

        //public virtual User Dentist { get; set; }
        public virtual Dentist Dentist { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
