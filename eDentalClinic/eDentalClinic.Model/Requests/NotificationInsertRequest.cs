using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class NotificationInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public int UserID { get; set; }
    }
}
