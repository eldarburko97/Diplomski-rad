using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class User
    {
        public int UserID { get; set; }
        public int DentalClinicID { get; set; }
        public int CityID { get; set; }
        public int GenderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Image { get; set; }

        public City City { get; set; }
        public Gender Gender { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
