using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class AppointmentDate
    {
        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
