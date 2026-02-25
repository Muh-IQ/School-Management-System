using Modules.School.Domain.DTOs;
using Modules.School.Domain.Common.Results;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result> CreateAsync(SchoolAddCommand school);

        Task<Result> UpdateAsync(Guid Id, SchoolUpdateCommand updatedSchool);

        Task<Result> SoftDeleteAsync(Guid schoolId);

        Task<Result> SetActiveStatusAsync(Guid schoolId, bool isActive);

    }
}
