using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Topic
    {
        public int TopicID { get; set; }
        //public int ClientID { get; set; }
        public int UserID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        //public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
