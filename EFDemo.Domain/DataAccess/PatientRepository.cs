using EFDemo.Domain.DataAccess.Interfaces;
using EFDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDemo.Domain.DataAccess
{
    public class PatientRepository : IPatientRepository
    {
        private readonly EFDemoContext _context;
        public PatientRepository(EFDemoContext context)
        {
            _context = context;
        }


        public List<Patient> RetrieveAll()
        {
            return _context.Patients.ToList();
        }
        public Patient Retrieve(int patientId)
        {
            return null;
        }
        public int  Insert(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient.PatientId;

        }
        public int Update(Patient patient)
        {
            if (patient==null)
            {
                throw new System.ArgumentException("parameter cannot be null", "patient");
               
            }
            _context.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return patient.PatientId;
        }
        public void  Remove(int patientId)
        {
            var patient = Retrieve(patientId);
            if (patient == null)
            {
                throw new System.ArgumentException("Remove error");

            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
