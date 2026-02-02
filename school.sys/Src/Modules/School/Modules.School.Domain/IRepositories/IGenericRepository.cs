namespace Modules.School.Domain.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(int page=1, int pageSize=10);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
