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
    public class RatingService : CRUDService<eDentalClinic.Model.Rating, RatingSearchRequest, Database.Rating, RatingInsertRequest, RatingInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public RatingService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Rating> GetAll(RatingSearchRequest searchRequest)
        {
            var query = _context.Ratings.Include(i => i.User).Include(i => i.Dentist).ThenInclude(t => t.Branch).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRequest.DentistName))
            {
                query = query.Where(w => w.Dentist.FirstName.StartsWith(searchRequest.DentistName));
            }

            if (!string.IsNullOrWhiteSpace(searchRequest.DentistSurname))
            {
                query = query.Where(w => w.Dentist.LastName.StartsWith(searchRequest.DentistSurname));
            }

            if(searchRequest != null && searchRequest.DentistID != 0)              //From web API
            {
                query = query.Where(w => w.DentistID == searchRequest.DentistID);
            }

            return _mapper.Map<List<eDentalClinic.Model.Rating>>(query.ToList());
        }

        public override eDentalClinic.Model.Rating GetById(int id)
        {
            var query = _context.Ratings.Include(i => i.User).Include(i => i.Dentist).ThenInclude(t => t.Branch).FirstOrDefault(f => f.RatingID == id);
            return _mapper.Map<eDentalClinic.Model.Rating>(query);
        }
    }
}
