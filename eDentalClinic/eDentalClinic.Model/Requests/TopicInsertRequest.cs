using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class TopicInsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Subject { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
