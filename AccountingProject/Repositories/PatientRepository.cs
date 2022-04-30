using AccountingProject.Contracts;
using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Repositories
{
    public class PatientRepository: RepositoryBase<Patient>, IPatientRepository<Patient>
    {
        public PatientRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
