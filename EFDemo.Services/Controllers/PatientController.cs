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
        private readonly IPatientInserter _patientInserter;
        private readonly IPatientUpdater _patientUpdater;
        private readonly IPatientRemover _patientRemover;

        public PatientController(IPatientRetriever patentRetriever,IMapper mapper,
            IPatientInserter patientInserter,
            IPatientUpdater patientUpdater,
            IPatientRemover patientRemover
           )
        {
            _patentRetriever = patentRetriever;
            _patientInserter = patientInserter;
            _patientUpdater = patientUpdater;
            _patientRemover = patientRemover;
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
            _patientInserter.Insert(_mapper.Map<PatientModel,Patient>(patientModel));
            return Ok("Patient Record has been saved successfully");
        }
        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody]PatientModel patientModel)
        {
            _patientUpdater.Update(_mapper.Map<PatientModel, Patient>(patientModel));
            return Ok("Patient Record has been updated successfully");
        }

        [HttpDelete, Route("Delete/{patientId}")]
        public IActionResult Remove(int patientId)
        {
            _patientRemover.Remove(patientId);
            return Ok("Patient Record has been deleted successfully");
        }

    }
}