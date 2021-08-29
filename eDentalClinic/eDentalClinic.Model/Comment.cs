using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
   public class Comment
    {
        public int TopicID { get; set; }
        public int UserID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; } //Firstname + lastname
        public byte[] Image { get; set; }

        public  Topic Topic { get; set; }
    }
}
