using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
    public class DashboardDTO
    {
        public int Dentists { get; set; }
        public int Clients { get; set; }
        public int Appointments { get; set; }
        public double Earnings { get; set; }
        public IEnumerable<AppointmentDTO> RecentAppointments { get; set; }
    }
}
