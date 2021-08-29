using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Title
    {
        public int TitleID { get; set; }
        public string Name { get; set; }

        // public virtual ICollection<Dentist> Dentists { get; set; }
      //  public virtual ICollection<User> Dentists { get; set; }
    }
}
