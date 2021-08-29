using AutoMapper;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class TreatmentService : CRUDService<eDentalClinic.Model.Treatment, TreatmentSearchRequest, Database.Treatment, TreatmentInsertRequest, TreatmentInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public TreatmentService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Treatment> GetAll(TreatmentSearchRequest searchRequest)
        {
            var query = _context.Treatments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRequest.Name))
            {
                query = query.Where(w => w.Name.Contains(searchRequest.Name));
            }

            if(searchRequest.Price != 0)
            {
                query = query.Where(w => w.Price == searchRequest.Price);
            }

            if(searchRequest.TimeRequired != 0)
            {
                query = query.Where(w => w.TimeRequired == searchRequest.TimeRequired);
            }

            query = query.OrderBy(w => w.Price);
            return _mapper.Map<List<eDentalClinic.Model.Treatment>>(query.ToList());
        }
    }
}
