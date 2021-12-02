using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public interface IUserService
    {
        List<User> GetAll(UserSearchRequest search);
        User GetById(int userId);
        User Insert(UserInsertRequest request);
        User Update(int id, UserInsertRequest request);
        User Authenticate(string username, string password);

    }
}
