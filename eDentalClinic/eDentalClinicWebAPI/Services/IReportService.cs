using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;

namespace eDentalClinicWebAPI.Services
{
    public interface IReportService
    {
        List<BestSellingTreatment> GetBestSellingTreatments(ReportSearchRequest request);
        List<BusinessReportDentist> GetBusinessReportDentists(ReportSearchRequest request);
    }
}
