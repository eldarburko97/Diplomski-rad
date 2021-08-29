using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
    }
}
