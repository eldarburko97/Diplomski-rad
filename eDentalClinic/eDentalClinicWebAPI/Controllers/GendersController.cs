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
    public class GendersController : BaseCRUDController<Gender, GenderSearchRequest, GenderInsertRequest, GenderInsertRequest>
    {
        public GendersController(ICRUDService<Gender, GenderSearchRequest, GenderInsertRequest, GenderInsertRequest> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}