using eDentalClinic.Model;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<BusinessReportDentist> GetBusinessReportDentists(DateTime startDate, DateTime endDate)
        {
            return _service.GetBusinessReportDentists(startDate, endDate);
        }

        [HttpGet("get-best-selling-treatment")]
        public List<BestSellingTreatment> GetBestSellingTreatments(DateTime startDate, DateTime endDate)
        {
            return _service.GetBestSellingTreatments(startDate, endDate);
        }

    }
}
