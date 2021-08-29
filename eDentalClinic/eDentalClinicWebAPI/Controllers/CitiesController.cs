using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseCRUDController<City, CitySearchRequest, CityInsertRequest, CityInsertRequest>
    {
        public CitiesController(ICRUDService<City, CitySearchRequest, CityInsertRequest, CityInsertRequest> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}