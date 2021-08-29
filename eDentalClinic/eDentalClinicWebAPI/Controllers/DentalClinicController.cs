using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDentalClinic.Model;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentalClinicController : ControllerBase
    {
        private readonly IDentalClinicService _service;
        public DentalClinicController(IDentalClinicService service)
        {
            _service = service;
        }

        [HttpGet("{clinicId}")]
        public ActionResult<DentalClinic> GetById(int clinicId)
        {
            return _service.GetById(clinicId);
        }
    }
}