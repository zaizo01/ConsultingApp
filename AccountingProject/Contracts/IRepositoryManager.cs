using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Contracts
{
    public interface IRepositoryManager
    {
        IDoctorRepository<Doctor> Doctor{ get; }
        void Save();
    }
}
