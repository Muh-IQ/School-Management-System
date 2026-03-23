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
    }
}
