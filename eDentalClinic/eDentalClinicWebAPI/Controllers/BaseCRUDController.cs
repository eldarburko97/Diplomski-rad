using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eDentalClinicWebAPI.Filters;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDentalClinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : ControllerBase
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        private readonly IMapper _mapper = null;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public List<T> GetAll([FromQuery]TSearch request)
        {
            return _service.GetAll(request);
        }
        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _service.GetById(id);
        }
        
        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody]TInsert request)
        {
            try
            {
                return Ok(_service.Insert(request));
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException)
                {
                    throw new UserException("Cannot insert duplicate");
                }
                else throw new Exception();
                throw new Exception(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public T Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public T Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}