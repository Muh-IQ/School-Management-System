using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SchoolDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(SchoolDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            var result= await _context.SaveChangesAsync();
            return result > 0 ;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>>predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            var updated= await _context.SaveChangesAsync();
            return updated > 0 ; 
        }
    }
}
