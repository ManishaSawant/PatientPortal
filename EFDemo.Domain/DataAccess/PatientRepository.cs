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

        public EFDemoContext Context { get; }

        public List<Patient> RetrieveAll()
        {
            return _context.Patients.ToList();
        }
    }
}
