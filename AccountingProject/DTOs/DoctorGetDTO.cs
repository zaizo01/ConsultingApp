using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.DTOs
{
    public class DoctorGetDTO
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
    }
}
