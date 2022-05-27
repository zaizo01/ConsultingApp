using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class Inquiry
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string InquiryType { get; set; }
        public string InquiryPlace { get; set; }
    }
}
