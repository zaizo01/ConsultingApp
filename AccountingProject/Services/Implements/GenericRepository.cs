using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Services.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repository;

        public GenericRepository(IGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public async Task Delete(Guid id)
        {
            await repository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await repository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }
    }
}
