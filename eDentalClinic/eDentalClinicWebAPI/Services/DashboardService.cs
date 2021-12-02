using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using System.Linq;

namespace eDentalClinicWebAPI.Services
{
    public class DashboardService : IDashboardService
    {
        private eDentalClinicContext _context;
        private readonly ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, DentistAddDTO, DentistAddDTO> _dentistService;
        private readonly ICRUDService<eDentalClinic.Model.Appointment, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentInsertRequest> _appointmentService;
        private readonly ICRUDService<eDentalClinic.Model.Payment, PaymentSearchRequest, PaymentInsertRequest, PaymentInsertRequest> _paymentService;
        private readonly IUserService _userService;

        public DashboardService(eDentalClinicContext context,ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, eDentalClinic.Model.DentistAddDTO, eDentalClinic.Model.DentistAddDTO> dentistService, 
            IUserService userService,
            ICRUDService<eDentalClinic.Model.Appointment, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentInsertRequest> appointmentService,
            ICRUDService<eDentalClinic.Model.Payment, PaymentSearchRequest, PaymentInsertRequest, PaymentInsertRequest> paymentService)
        {
            _context = context;
            _dentistService = dentistService;
            _userService = userService;
            _appointmentService = appointmentService;
            _paymentService = paymentService;
        }
        public DashboardDTO GetDashboardInfo()
        {
            DashboardDTO dashboard = new DashboardDTO
            {
                Dentists = _dentistService.GetCount(),
                Clients = _context.Users.Where(x => x.UserRoles.Any(s => s.Role.Name == "Client")).Count(),
                Appointments = _appointmentService.GetCount(),
                RecentAppointments = _context.Appointments.Select(x => new AppointmentDTO() { Client = x.User.FirstName + " " + x.User.LastName, Dentist = x.Dentist.Branch.Title + " " + x.Dentist.FirstName + " " +  x.Dentist.LastName, EndDate = x.EndDate, StartDate = x.StartDate, Treatment = x.Treatment.Name }),
                Earnings = (double)_context.Payments.Sum(s => s.Amount)
            };

            return dashboard;
        }
    }
}
