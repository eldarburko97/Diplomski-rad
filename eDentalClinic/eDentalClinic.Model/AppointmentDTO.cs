using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class AppointmentDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Treatment { get; set; }
        public string Dentist { get; set; }
        public string Client { get; set; }
    }
}
