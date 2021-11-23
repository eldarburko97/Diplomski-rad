//using eDentalClinic.Model;
using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : /*ControllerBase*/  BaseCRUDController<eDentalClinic.Model.Dentist, DentistSearchRequest, eDentalClinic.Model.DentistAddDTO, eDentalClinic.Model.DentistAddDTO>
    {

        public DentistsController(ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, eDentalClinic.Model.DentistAddDTO, eDentalClinic.Model.DentistAddDTO> service, IMapper mapper) : base(service, mapper)
        {

        }

        //private readonly ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, eDentalClinic.Model.DentistAddDTO, DentistInsertRequest> _service;
        //public DentistsController(ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, eDentalClinic.Model.DentistAddDTO, DentistInsertRequest> service)
        //{
        //    _service = service;
        //}

        //[HttpPost]
        //public eDentalClinic.Model.Dentist Insert([FromForm] eDentalClinic.Model.DentistAddDTO dentist)
        //{
        //    return _service.Insert(dentist);
        //}


    }
}