using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class VideoInquiry
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string VideoInquiryPerson { get; set; }
        public string VideoInquiryPersonFirstname { get; set; }
        public string VideoInquiryPersonLastName { get; set; }

    }
}
