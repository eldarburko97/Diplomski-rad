using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eDentalClinicWebAPI.Services
{
    public class DentistService : CRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, Database.Dentist, eDentalClinic.Model.DentistAddDTO, eDentalClinic.Model.DentistAddDTO>
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

        public override eDentalClinic.Model.Dentist Insert(eDentalClinic.Model.DentistAddDTO dentist)
        {
            var entity = new Dentist
            {
                DentalClinicID = 1,
                BranchID = dentist.BranchID,
                FirstName = dentist.FirstName,
                LastName = dentist.LastName,
                Phone = dentist.Phone,
                Email = dentist.Email,
                Address = dentist.Address,
                BirthDate = dentist.BirthDate,
                Description = dentist.Description,
                Active = dentist.Active
            };

            if (dentist.Image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    dentist.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    entity.Image = fileBytes;
                    //string s = Convert.ToBase64String(fileBytes);
                }
            }

            _context.Dentists.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<eDentalClinic.Model.Dentist>(entity);
        }

        public override eDentalClinic.Model.Dentist Update(int id, eDentalClinic.Model.DentistAddDTO dentist)
        {
            var entity = _context.Dentists.Find(id);
            entity.DentalClinicID = 1;
            entity.BranchID = dentist.BranchID;
            entity.FirstName = dentist.FirstName;
            entity.LastName = dentist.LastName;
            entity.Phone = dentist.Phone;
            entity.Email = dentist.Email;
            entity.Address = dentist.Address;
            entity.BirthDate = dentist.BirthDate;
            entity.Description = dentist.Description;
            entity.Active = dentist.Active;

            if (dentist.Image == null)
            {
                var existingDentist = GetById(id);
                entity.Image = existingDentist.Image;
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    dentist.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    entity.Image = fileBytes;
                }
            }

            _context.Dentists.Attach(entity);
            _context.Dentists.Update(entity);
            _context.SaveChanges();
            return _mapper.Map<eDentalClinic.Model.Dentist>(entity);
        }
    }
}
