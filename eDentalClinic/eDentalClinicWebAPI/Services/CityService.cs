using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class CityService : CRUDService<eDentalClinic.Model.City, CitySearchRequest, Database.City, CityInsertRequest, CityInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public CityService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
