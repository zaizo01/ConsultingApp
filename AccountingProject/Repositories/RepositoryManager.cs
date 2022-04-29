using AccountingProject.Contracts;
using AccountingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext context;
        private IDoctorRepository<Doctor> _doctorRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IDoctorRepository<Doctor> Doctor
        {
            get
            {
                if (_doctorRepository == null)
                    _doctorRepository = new DoctorRepository(context);
                return _doctorRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
