using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
    }
}
