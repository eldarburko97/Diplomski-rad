using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
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
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }


        public virtual DentalClinic DentalClinic { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Branch Branch { get; set; }                                           
    }
}
