using eDentalClinic.Model;
using System;
using System.Collections.Generic;

namespace eDentalClinicWebAPI.Services
{
    public interface IReportService
    {
        List<BestSellingTreatment> GetBestSellingTreatments(DateTime startDate, DateTime endDate);
        List<BusinessReportDentist> GetBusinessReportDentists(DateTime startDate, DateTime endDate);
    }
}
