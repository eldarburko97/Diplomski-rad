using AutoMapper;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class NotificationService : CRUDService<eDentalClinic.Model.Notification, NotificationSearchRequest, Database.Notification, NotificationInsertRequest, NotificationInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public NotificationService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Notification> GetAll(NotificationSearchRequest searchRequest)
        {
            var query = _context.Notifications.Include(i => i.User).AsQueryable();

            if(searchRequest != null && searchRequest.StartDate != null && searchRequest.EndDate != null)
            {
                query = query.Where(w => w.NotificationDate.Date >= searchRequest.StartDate.Value.Date && w.NotificationDate.Date <= searchRequest.EndDate.Value.Date);
            }
            return _mapper.Map<List<eDentalClinic.Model.Notification>>(query.ToList());
        }
    }
}
