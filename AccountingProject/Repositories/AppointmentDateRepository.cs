using AccountingProject.Contracts;
using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Repositories
{
    public class AppointmentDateRepository: RepositoryBase<AppointmentDate>, IAppointmentDateRepository<AppointmentDate>
    {
        public AppointmentDateRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
