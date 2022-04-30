using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Contracts
{
    public interface IRepositoryManager
    {
        IDoctorRepository<Doctor> Doctor { get; }
        IPatientRepository<Patient> Patient { get; }
        IAppointmentDateRepository<AppointmentDate> AppointmentDate { get;  }
        void Save();
    }
}
