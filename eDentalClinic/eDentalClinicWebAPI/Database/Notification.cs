using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Column(TypeName = "date")]
        public DateTime NotificationDate { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
