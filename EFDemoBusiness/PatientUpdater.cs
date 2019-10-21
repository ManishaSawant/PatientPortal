using EFDemo.Domain.DataAccess.Interfaces;
using EFDemo.Domain.Entities;
using EFDemoBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoBusiness
{
    public class PatientUpdater : IPatientUpdater
    {
        private readonly IPatientRepository _patientRepository;

        public PatientUpdater(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public int Update(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
    }
}
