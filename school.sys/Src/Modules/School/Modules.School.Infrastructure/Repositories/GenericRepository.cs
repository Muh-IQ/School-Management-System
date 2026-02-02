using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories
{
    internal class GenericRepository<T>(SchoolDbContext context) : IGenericRepository<T> where T : class
    {
        public async Task AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }
        public Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
