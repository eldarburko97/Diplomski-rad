using AutoMapper;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using eDentalClinicWebAPI.Filters;
using eDentalClinicWebAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class UserService : IUserService
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public UserService(eDentalClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public eDentalClinic.Model.User Authenticate(string username, string password)
        {
            var user = _context.Users.Include("UserRoles.Role").FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                var newHash = HashGenerator.GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<eDentalClinic.Model.User>(user);
                }
            }
            return null;
        }

        public eDentalClinic.Model.User GetById(int userId)
        {
            var entity = _context.Users.Include(i => i.City).Include(i => i.Gender).FirstOrDefault(f => f.UserID == userId);
            return _mapper.Map<eDentalClinic.Model.User>(entity);
        }

        //[Authorize]
        public List<eDentalClinic.Model.User> GetAll(UserSearchRequest search)
        {
            var query = _context.Users.Include("UserRoles.Role").Include(i => i.Gender).Include(i => i.City).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username == search.Username);
            }

            if (!string.IsNullOrWhiteSpace(search?.FirstName))
            {
                query = query.Where(x => x.FirstName == search.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(search?.LastName))
            {
                query = query.Where(x => x.LastName == search.LastName);
            }
            return _mapper.Map<List<eDentalClinic.Model.User>>(query.ToList());            
        }

        public eDentalClinic.Model.User Insert(UserInsertRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException("Password and password confirm do not match!");
            }
            var entity = _mapper.Map<Database.User>(request);
            entity.PasswordSalt = HashGenerator.GenerateSalt();
            entity.PasswordHash = HashGenerator.GenerateHash(entity.PasswordSalt, request.Password);
            _context.Users.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<eDentalClinic.Model.User>(entity);
        }

        public eDentalClinic.Model.User Update(int id, UserInsertRequest request)
        {
            if(request.Password != request.ConfirmPassword)
            {
                throw new UserException("Password and password confirm do not match!");
            }
            var entity = _context.Users.Find(id);
            if (!string.IsNullOrEmpty(request.Password))
            {
                entity.PasswordHash = HashGenerator.GenerateHash(entity.PasswordSalt, request.Password);
            }
            _mapper.Map(request, entity);
            _context.Users.Attach(entity);
            _context.Users.Update(entity);
            _context.SaveChanges();
            return _mapper.Map<eDentalClinic.Model.User>(entity);
        }        
    }
}
