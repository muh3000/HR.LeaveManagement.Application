using HR.LeaveManagement.Application.Persistace.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;

        public GenericRepository(LeaveManagementDbContext leaveManagementDbContext)
        {
            _dbContext = leaveManagementDbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
