using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
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
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Image { get; set; }

        public virtual DentalClinic DentalClinic { get; set; }
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        // public virtual Title Title { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
          public virtual ICollection<Rating> Ratings { get; set; }
          public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        // public virtual ICollection<DentistTreatmentType> DentistTreatmentTypes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
