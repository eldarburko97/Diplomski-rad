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
    public class PaymentService : CRUDService<eDentalClinic.Model.Payment, PaymentSearchRequest, Database.Payment, PaymentInsertRequest, PaymentInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public PaymentService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Payment> GetAll(PaymentSearchRequest searchRequest)
        {
            var query = _context.Payments.Include(i => i.User).Include(i => i.Treatment).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRequest?.FirstName))
            {
                query = query.Where(w => w.User.FirstName.StartsWith(searchRequest.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(searchRequest?.LastName))
            {
                query = query.Where(w => w.User.LastName.StartsWith(searchRequest.LastName));
            }

            if (!string.IsNullOrWhiteSpace(searchRequest?.Treatment))
            {
                query = query.Where(w => w.Treatment.Name.StartsWith(searchRequest.Treatment));
            }

            if(searchRequest != null && searchRequest.DateFrom != null && searchRequest.DateTo != null)
            {
                query = query.Where(w => w.Date >= searchRequest.DateFrom.Value.Date && w.Date <= searchRequest.DateTo.Value.Date);
            }

            if(searchRequest != null && searchRequest.UserID != 0)
            {
                query = query.Where(w => w.UserID == searchRequest.UserID);
            }

            return _mapper.Map<List<eDentalClinic.Model.Payment>>(query.ToList());
        }
    }
}
