using AccountingProject.DTOs;
using AccountingProject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Extensions
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Doctor, DoctorGetDTO>().ReverseMap();
            CreateMap<Doctor, DoctorPostDTO>().ReverseMap();
            CreateMap<Patient, PatientGetDTO>().ReverseMap();
            CreateMap<Patient, PatientPostDTO>().ReverseMap();
            CreateMap<AppointmentDate, AppointmentDatePostDTO> ().ReverseMap();
            CreateMap<AppointmentDate, AppointmentDateGetDTO> ().ReverseMap();
            CreateMap<AppointmentDate, ListOfDateByDoctors>().ReverseMap();
            CreateMap<AppointmentDate, ListOfDatesByPatient>().ReverseMap();
        }
    }
}
