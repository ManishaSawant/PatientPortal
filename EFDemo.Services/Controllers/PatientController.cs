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
        private readonly IPatientInserter _PatientInserter;
        private readonly IPatientUpdater _PatientUpdater;
        private readonly IPatientRemover _PatientRemover;
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
            //return Ok(_mapper.Map<IList<Patient>,IList<PatientModel>>(_patentRetriever.RetrieveAll()));
        }
         [HttpPost,Route("Insert")]
        public IActionResult Insert([FromBody]PatientModel patientModel )
        {
            _PatientInserter.Insert(_mapper.Map<PatientModel,Patient>(patientModel));
            return Ok("Patient Record has been saved successfully");
        }
        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody]PatientModel patientModel)
        {
            _PatientUpdater.Update(_mapper.Map<PatientModel, Patient>(patientModel));
            return Ok("Patient Record has been updated successfully");
        }

        [HttpDelete, Route("Delete/{patientId}")]
        public IActionResult Remove(int patientId)
        {
            _PatientRemover.Remove(patientId);
            return Ok("Patient Record has been deleted successfully");
        }

    }
}