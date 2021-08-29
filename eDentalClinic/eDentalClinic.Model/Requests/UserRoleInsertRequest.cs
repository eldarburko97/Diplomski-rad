using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class UserRoleInsertRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoleID { get; set; }
    }
}
