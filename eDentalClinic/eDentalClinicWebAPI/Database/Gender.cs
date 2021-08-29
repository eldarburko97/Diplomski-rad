using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string Type { get; set; }

       // public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
