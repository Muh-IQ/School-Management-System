using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    }
}
