using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Entities;

namespace Modules.School.Application.IServices
{
    public interface IPolicyService
    {
        Task<Result> CreateAsync(Policy policy);

        Task<Result<Policy>> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Policy>>> GetAllAsync();

        Task<Result<IEnumerable<Policy>>> GetAllAsync(int paging = 1, int pageSize = 10);

        Task<Result> UpdateAsync(Policy policy);

        Task<Result> DeleteAsync(Guid Id);
    }
}
