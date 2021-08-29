using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
  public  class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
