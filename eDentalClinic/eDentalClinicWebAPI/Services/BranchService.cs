using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;

namespace eDentalClinicWebAPI.Services
{
    public class BranchService : CRUDService<eDentalClinic.Model.Branch, BranchSearchRequest, Database.Branch, BranchInsertRequest, BranchInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public BranchService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public override List<eDentalClinic.Model.Branch> GetAll(BranchSearchRequest request)
        {
            var query = _context.Branches.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                //query = query.Where(x => x.Name == request.Name);
                query = query.Where(x => x.Name.Contains(request.Name));
            }
            //if (!string.IsNullOrWhiteSpace(request.Title))
            //{
            //    query = query.Where(x => x.Title.Contains(request.Title));
            //}
            var list = query.ToList();
            return _mapper.Map<List<eDentalClinic.Model.Branch>>(query.ToList());
        }
    }
}
