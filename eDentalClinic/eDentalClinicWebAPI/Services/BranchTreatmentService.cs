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
    public class BranchTreatmentService : CRUDService<eDentalClinic.Model.BranchTreatment, BranchTreatmentSearchRequest, Database.BranchTreatment, BranchTreatmentInsertRequest, BranchTreatmentInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;

        public BranchTreatmentService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.BranchTreatment> GetAll(BranchTreatmentSearchRequest searchRequest)
        {
            var query = _context.BranchTreatments.Include(i => i.Branch).Include(i => i.Treatment).AsQueryable();

            if(searchRequest.BranchID != 0)
            {
                query = query.Where(w => w.BranchID == searchRequest.BranchID);
            }
            var list = query.ToList();
            return _mapper.Map<List<eDentalClinic.Model.BranchTreatment>>(list);
        }
    }
}
