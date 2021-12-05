using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eDentalClinicWebAPI.Services
{
    public class ReportService : IReportService
    {
        private eDentalClinicContext _context;
        public ReportService(eDentalClinicContext context)
        {
            _context = context;
        }
        public List<BestSellingTreatment> GetBestSellingTreatments(ReportSearchRequest request)
        {

            var appointments = _context.Appointments.ToList();
            int count = 0;
            foreach (var item in appointments)
            {
                if (item.StartDate >= request.StartDate && item.EndDate <= request.EndDate)
                {
                    count++;
                }
            }


            return (from t in _context.Treatments
                    join a in _context.Appointments
                    on t.TreatmentID equals a.TreatmentID
                    where a.StartDate >= request.StartDate && a.EndDate <= request.EndDate
                    group t by t.Name into g
                    select new BestSellingTreatment
                    {
                        Treatment = g.Key,
                        Number = g.Count(),
                        Total = g.Sum(t => t.Price)
                    }).ToList();
        }

        public List<BusinessReportDentist> GetBusinessReportDentists(ReportSearchRequest request)
        {

           



            return (from d in _context.Dentists
                        join a in _context.Appointments
                        on d.DentistID equals a.DentistID
                        where a.StartDate >= request.StartDate && a.EndDate <= request.EndDate
                        group d by d.FirstName + " " + d.LastName into g
                                    select new BusinessReportDentist
                                    {
                                        Name = g.Key,
                                        TotalAppointments = g.Count(),
                                    }).ToList();
        }
    }
}
