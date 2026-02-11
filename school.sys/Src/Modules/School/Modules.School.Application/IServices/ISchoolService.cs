using Modules.School.Domain.Common.Results;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result> CreateAsync(Domain.Entities.School school);

        Task<Result> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync();

        Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync(int paging = 1, int pageSize = 10);

        Task<Result> UpdateAsync(Domain.Entities.School school);

        Task<Result> DeleteAsync(Guid Id);
    }
}
