using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class Topic
    {
        public int TopicID { get; set; }
        public int UserID { get; set; }
        public string Client { get; set; } //First name + last name
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Comments { get; set; }
        public string LastComment { get; set; }
    }
}
