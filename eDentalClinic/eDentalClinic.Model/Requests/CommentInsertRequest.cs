using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDentalClinic.Model.Requests
{
   public class CommentInsertRequest
    {
        [Required]
        public int TopicID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
