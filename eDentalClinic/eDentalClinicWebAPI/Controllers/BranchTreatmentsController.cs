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
    public class BranchTreatmentsController : BaseCRUDController<BranchTreatment, BranchTreatmentSearchRequest, BranchTreatmentInsertRequest, BranchTreatmentInsertRequest>
    {
        public BranchTreatmentsController(ICRUDService<BranchTreatment, BranchTreatmentSearchRequest, BranchTreatmentInsertRequest, BranchTreatmentInsertRequest> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}