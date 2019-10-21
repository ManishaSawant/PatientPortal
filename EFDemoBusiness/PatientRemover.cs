using EFDemo.Domain.DataAccess.Interfaces;
using EFDemoBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoBusiness
{
    public class PatientRemover : IPatientRemover
    {
        private readonly IPatientRepository _pateintRepository;

        public PatientRemover(IPatientRepository PateintRepository)
        {
            _pateintRepository = PateintRepository;
        }
        public void Remove(int patientId)
        {
            _pateintRepository.Remove(patientId);
        }
    }
}
