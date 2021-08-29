using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class UserRoleService : CRUDService<eDentalClinic.Model.UserRole, object, Database.UserRole, UserRoleInsertRequest, UserRoleInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public UserRoleService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
