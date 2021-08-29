using AutoMapper;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class AppointmentService : CRUDService<eDentalClinic.Model.Appointment, AppointmentSearchRequest, Database.Appointment, AppointmentInsertRequest, AppointmentInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public AppointmentService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Appointment> GetAll(AppointmentSearchRequest request)
        {
            var query = _context.Appointments.Include(i => i.User).Include(i => i.Dentist).Include(i => i.Treatment).AsQueryable();

            if (request.UserID != 0) // Returns all appointments of logged in Client
            {
                query = query.Where(w => w.UserID == request.UserID);
            }

            if (!string.IsNullOrWhiteSpace(request.DentistName))
            {
                query = query.Where(w => w.Dentist.FirstName.StartsWith(request.DentistName));
            }

            if (!string.IsNullOrWhiteSpace(request.DentistSurname))
            {
                query = query.Where(w => w.Dentist.LastName.StartsWith(request.DentistSurname));
            }

            if (!string.IsNullOrWhiteSpace(request.ClientName))
            {
                query = query.Where(w => w.User.FirstName.StartsWith(request.ClientName));
            }

            if (!string.IsNullOrWhiteSpace(request.ClientSurname))
            {
                query = query.Where(w => w.User.LastName.StartsWith(request.ClientSurname));
            }

            if (!string.IsNullOrWhiteSpace(request.TreatmentName))
            {
                query = query.Where(w => w.Treatment.Name == request.TreatmentName);
            }

            if (request.StartDate != null && request.EndDate != null)
            {
                query = query.Where(w => w.StartDate.Date >= request.StartDate.Value.Date && w.EndDate.Date <= request.EndDate.Value.Date);
            }

            query = query.OrderBy(w => w.AppointmentID);
            return _mapper.Map<List<eDentalClinic.Model.Appointment>>(query.ToList());
        }

        public override eDentalClinic.Model.Appointment GetById(int id)
        {
            var query = _context.Appointments.Include(i => i.User).Include(i => i.Dentist).Include(i => i.Treatment).FirstOrDefault(f => f.AppointmentID == id);
            return _mapper.Map<eDentalClinic.Model.Appointment>(query);
        }


        

        public override eDentalClinic.Model.Appointment Insert(AppointmentInsertRequest model)       
        {
            var entity = _context.Appointments.Where(x => x.DentistID == model.DentistID).ToList();

            foreach (var e in entity)
            {
                if ((e.StartDate == model.StartDate) || (e.StartDate < model.StartDate && e.EndDate > model.StartDate) || (e.StartDate < model.EndDate && e.EndDate > model.EndDate))
                    return null;
            }

            Database.Appointment appointment = _mapper.Map<Database.Appointment>(model);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return _mapper.Map<eDentalClinic.Model.Appointment>(appointment);
        }
    }
}
