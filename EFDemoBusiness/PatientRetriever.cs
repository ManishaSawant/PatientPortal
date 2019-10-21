using EFDemo.Domain.DataAccess.Interfaces;
using EFDemo.Domain.Entities;
using EFDemoBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;


namespace EFDemoBusiness
{
    public class PatientRetriever : IPatientRetriever
    {
        private readonly IPatientRepository _PatientRepository;

     
        
        public PatientRetriever(IPatientRepository PatientRepository)
        {
            _PatientRepository = PatientRepository;
        }

        public List<Patient> RetrieveAll()
        {
         
           return _PatientRepository.RetrieveAll();
        }
    }
}
