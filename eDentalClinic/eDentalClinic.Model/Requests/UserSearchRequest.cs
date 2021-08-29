using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class UserSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
