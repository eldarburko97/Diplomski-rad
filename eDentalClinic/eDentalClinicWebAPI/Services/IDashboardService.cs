using eDentalClinic.Model;
using System.Collections.Generic;

namespace eDentalClinicWebAPI.Services
{
    public interface IDashboardService
    {
        //int GetDashboardInfo();
        //List<Appointment> GetRecentAppointments();
        DashboardDTO GetDashboardInfo();
    }
}
