using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFDemo.Domain.Entities;
using EFDemo.Services.Model;
using EFDemoBusiness;
using EFDemoBusiness.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDemo.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRetriever _patentRetriever;
        private readonly IMapper _mapper;

        public PatientController(IPatientRetriever patentRetriever,IMapper mapper)
        {
            _patentRetriever = patentRetriever;
            _mapper = mapper;
        }
        //
        public IActionResult Get()
        {
           return Ok(_mapper.Map<List<Patient>,List<PatientModel>>( _patentRetriever.RetrieveAll()));
         }

    }
}