using EFDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemoBusiness.Interfaces
{
    public interface IPatientUpdater
    {
        int Update(Patient patient);
    }
}
