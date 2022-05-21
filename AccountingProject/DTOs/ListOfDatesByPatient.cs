using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.DTOs
{
    public class ListOfDatesByPatient
    {
        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
