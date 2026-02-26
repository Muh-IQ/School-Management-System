using Modules.School.Domain.DTOs;
using Modules.School.Domain.Common.Results;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result> CreateAsync(SchoolAddCommand school);

        Task<Result> UpdateAsync(Guid Id, SchoolUpdateCommand updatedSchool);

        Task<Result> DeleteAsync(Guid schoolId);

        Task<Result> SetActiveStatusAsync(Guid schoolId, bool isActive);


        Task<Result<SchoolDetailsDTO?>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<SchoolListItemDTO>>> GetPagedAsync(int pageNumber = 1, int pageSize = 10);

    }
}
