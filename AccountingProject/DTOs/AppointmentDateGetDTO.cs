using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.DTOs
{
    public class AppointmentDateGetDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
