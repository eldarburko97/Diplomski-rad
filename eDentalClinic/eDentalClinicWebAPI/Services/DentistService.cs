using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class DentistService : CRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, Database.Dentist, DentistInsertRequest, DentistInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public DentistService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override eDentalClinic.Model.Dentist GetById(int id)
        {
             var entity = _context.Dentists.Include(i => i.Branch).ThenInclude(t => t.BranchTreatments).FirstOrDefault(f => f.DentistID == id);
            return _mapper.Map<eDentalClinic.Model.Dentist>(entity);
        } 

        public override List<eDentalClinic.Model.Dentist> GetAll(DentistSearchRequest request)
        {
            var query = _context.Dentists.Include(i => i.Branch).ThenInclude(t => t.BranchTreatments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                query = query.Where(x => x.FirstName.StartsWith(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                query = query.Where(x => x.LastName.StartsWith(request.LastName));
            }
            query = query.Include(i => i.Branch);
            return _mapper.Map<List<eDentalClinic.Model.Dentist>>(query.ToList());
        }
    }
}
