using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.DTOs
{
    public class AppointmentDatePostDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
    }
}
