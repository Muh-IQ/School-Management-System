using Modules.School.Domain.DTOs;
using Modules.School.Domain.Common.Results;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result> CreateAsync(SchoolAddDTO school);

        Task<Result<Domain.Entities.School>> GetByIdAsync(Guid id);
        Task<Result<SchoolDTO>> GetByIdAsDtoAsync(Guid id);

        Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync(int paging = 1, int pageSize = 10);
        Task<Result<IEnumerable<SchoolDTO>>> GetAllAsDtoAsync(int paging = 1, int pageSize = 10);

        Task<Result> UpdateAsync(Guid Id, SchoolUpdateDTO updatedSchool);

        Task<Result> DeleteAsync(Guid Id);
    }
}
