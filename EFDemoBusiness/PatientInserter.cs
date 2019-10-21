using EFDemo.Domain.DataAccess.Interfaces;
using EFDemo.Domain.Entities;
using EFDemoBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoBusiness
{
    public class PatientInserter : IPatientInserter
    {
        private readonly IPatientRepository _patientRepository;

        public PatientInserter(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public int Insert(Patient patient)
        {
            return _patientRepository.Insert(patient);
        }

    }
}
