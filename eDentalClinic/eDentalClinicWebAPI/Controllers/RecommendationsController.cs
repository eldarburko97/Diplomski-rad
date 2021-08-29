using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _service;
        public RecommendationsController(IRecommendationService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Dentist> Recommend([FromQuery] RecommendationSearchRequest request)
        {
            return _service.RecommendDentist(request.DentistID);
        }
    }
}