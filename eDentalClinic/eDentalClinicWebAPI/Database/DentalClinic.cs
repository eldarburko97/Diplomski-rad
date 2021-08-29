using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class DentalClinic
    {
        public int DentalClinicID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Dentist> Dentists { get; set; }
    }
}
