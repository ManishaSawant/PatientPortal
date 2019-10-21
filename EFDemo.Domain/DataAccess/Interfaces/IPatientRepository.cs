using EFDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo.Domain.DataAccess.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> RetrieveAll();
        Patient Retrieve(int patientId);
        int Insert(Patient patient);
        int Update(Patient patient);
        void Remove(int patientId);
    }

}
