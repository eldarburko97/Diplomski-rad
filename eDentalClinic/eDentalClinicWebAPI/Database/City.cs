using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }

       // public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
