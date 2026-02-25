using System.Linq.Expressions;


namespace Modules.School.Domain.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<bool>AnyAsync(Expression<Func<T,bool>> predicate);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber=1, int pageSize=10);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
