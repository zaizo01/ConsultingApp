using AccountingProject.DTOs;
using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Contracts
{
    public interface IAppointmentDateRepository<TEntity> : IRepositoryBase<AppointmentDate>
    {
        Task<int> ValidateEntities(AppointmentDatePostDTO appointmentDatePostDTO);
        Task<List<TEntity>> GetDoctorListOfDates(Guid doctorId);
        Task<List<TEntity>> GetPatientListOfDates(Guid patientId);
    }
}
