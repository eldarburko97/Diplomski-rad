using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class GenderService : CRUDService<eDentalClinic.Model.Gender, GenderSearchRequest, Database.Gender, GenderInsertRequest, GenderInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public GenderService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
