using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
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

        [HttpGet("get-business-report-dentists")]
        public List<BusinessReportDentist> GetBusinessReportDentists([FromQuery] ReportSearchRequest request)
        {
            return _service.GetBusinessReportDentists(request);
        }

        [HttpGet("get-best-selling-treatment")]
        public List<BestSellingTreatment> GetBestSellingTreatments([FromQuery] ReportSearchRequest request)
        {
            return _service.GetBestSellingTreatments(request);
        }

    }
}
