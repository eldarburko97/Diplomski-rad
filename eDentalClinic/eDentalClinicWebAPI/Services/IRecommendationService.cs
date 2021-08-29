using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
   public interface IRecommendationService
    {
        List<Dentist> RecommendDentist(int dentistID);
    }
}
