using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFDemo.Domain.Entities;
using EFDemo.Services.Model;

namespace EFDemo.Services.Profile
{
    public class ApplicationProfile :AutoMapper.Profile 
    {
        public ApplicationProfile()
        {
            CreateMap<Patient, PatientModel>().ReverseMap();
        }
    }
}
