using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eDentalClinic.Model;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eDentalClinicWebAPI.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly eDentalClinicContext _context;
        private readonly IMapper _mapper;
        public RecommendationService(eDentalClinicContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Dictionary<int, List<Database.Rating>> dentists = new Dictionary<int, List<Database.Rating>>();

        public List<eDentalClinic.Model.Dentist> RecommendDentist(int dentistID)
        {
            var tmp = LoadSimilar(dentistID);
            return _mapper.Map<List<eDentalClinic.Model.Dentist>>(tmp);
        }

        private List<Database.Dentist> LoadSimilar(int dentistID)
        {
            LoadOtherDentists(dentistID);
            List<Database.Rating> ratingOfCurrent = _context.Ratings.Where(w => w.DentistID == dentistID).OrderBy(w => w.UserID).ToList();

            List<Database.Rating> ratings1 = new List<Database.Rating>();
            List<Database.Rating> ratings2 = new List<Database.Rating>();
            List<Database.Dentist> recommendedDentists = new List<Database.Dentist>();

            foreach (var dentist in dentists)
            {
                foreach (Database.Rating rating in ratingOfCurrent)
                {
                    if(dentist.Value.Where(w => w.UserID == rating.UserID).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(dentist.Value.Where(w => w.UserID == rating.UserID).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if(similarity > 0.5)
                {
                    recommendedDentists.Add(_context.Dentists.Where(w => w.DentistID == dentist.Key).Include(i => i.Branch).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedDentists;
        }

        private double GetSimilarity(List<Database.Rating> ratings1, List<Database.Rating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }
            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].DentistRating * ratings2[i].DentistRating;
                y1 += ratings1[i].DentistRating * ratings1[i].DentistRating;
                y2 += ratings2[i].DentistRating * ratings2[i].DentistRating;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadOtherDentists(int dentistID)
        {
            List<Database.Dentist> list = _context.Dentists.Where(w => w.DentistID != dentistID).ToList();
            List<Database.Rating> ratings = new List<Database.Rating>();
            foreach (var item in list)
            {
                ratings = _context.Ratings.Where(w => w.DentistID == item.DentistID).OrderBy(w => w.UserID).ToList();
                if (ratings.Count > 0)
                {
                    dentists.Add(item.DentistID, ratings);
                }
            }
        }
    }
}
