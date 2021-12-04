using eDentalClinic.Model;
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
        public List<BestSellingTreatment> GetBestSellingTreatments(DateTime startDate, DateTime endDate)
        {
            return (from t in _context.Treatments
                    join a in _context.Appointments
                    on t.TreatmentID equals a.TreatmentID
                    where a.StartDate >= startDate && a.EndDate <= endDate
                    group t by t.Name into g
                    select new BestSellingTreatment
                    {
                        Treatment = g.Key,
                        Number = g.Count(),
                        Total = g.Sum(t => t.Price)
                    }).ToList();
        }

        public List<BusinessReportDentist> GetBusinessReportDentists(DateTime startDate, DateTime endDate)
        {
            return (from d in _context.Dentists
                        join a in _context.Appointments
                        on d.DentistID equals a.DentistID
                        where a.StartDate >= startDate && a.EndDate <= endDate
                        group d by d.FirstName + " " + d.LastName into g
                                    select new BusinessReportDentist
                                    {
                                        Name = g.Key,
                                        TotalAppointments = g.Count(),
                                    }).ToList();
        }
    }
}
