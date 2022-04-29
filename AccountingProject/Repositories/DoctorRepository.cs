using AccountingProject.Contracts;
using AccountingProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Repositories
{
    public class DoctorRepository: RepositoryBase<Doctor>, IDoctorRepository<Doctor>
    {
        private readonly ApplicationDbContext context;

        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Doctor> GetByName(string name)
        {
            var doctor = await context.Doctors.FirstOrDefaultAsync(x => x.FistName == name);
            return doctor;

        }
    }
}
