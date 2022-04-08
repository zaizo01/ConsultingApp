using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
