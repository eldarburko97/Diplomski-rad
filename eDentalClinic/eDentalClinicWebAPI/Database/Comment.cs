using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int TopicID { get; set; }
        public string Text { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
