using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
       // [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
       // [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage ="Incorrect format of email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
       // [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
     //   [Required(AllowEmptyStrings = false)]
        public string ConfirmPassword { get; set; }
        public byte[] Image { get; set; }
        public int CityID { get; set; }
        public int GenderID { get; set; }
        public int DentalClinicID { get; set; }
    }
}
