using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Contracts
{
    public interface IAppointmentDateRepository<TEntity> : IRepositoryBase<AppointmentDate>
    {
    }
}
