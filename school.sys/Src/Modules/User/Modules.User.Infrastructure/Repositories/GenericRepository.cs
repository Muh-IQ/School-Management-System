using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.IRepositories;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly UserDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(UserDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
