using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eDentalClinic.Model
{
   public class Dentist
    {
        public int DentistID { get; set; }
        public int DentalClinicID { get; set; }
        public int BranchID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public  Branch Branch { get; set; }
    }
}
