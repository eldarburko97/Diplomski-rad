using AutoMapper;
using eDentalClinicWebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class DentalClinicService : IDentalClinicService
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public DentalClinicService(eDentalClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public eDentalClinic.Model.DentalClinic GetById(int clinicId)
        {
            var entity = _context.DentalClinic.FirstOrDefault(f => f.DentalClinicID == clinicId);
            return _mapper.Map<eDentalClinic.Model.DentalClinic>(entity);
        }
    }
}
