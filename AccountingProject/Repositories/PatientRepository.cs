using AccountingProject.Contracts;
using AccountingProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Repositories
{
    public class PatientRepository: RepositoryBase<Patient>, IPatientRepository<Patient>
    {
        private readonly ApplicationDbContext context;
        public PatientRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }
    }
}
