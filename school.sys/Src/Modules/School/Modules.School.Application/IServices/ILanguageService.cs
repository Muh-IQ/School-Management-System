using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;

namespace Modules.School.Application.IServices
{

    public interface ILanguageService
    {
        Task<Result> CreateAsync(Language language);

        Task<Result<LanguageDTO>> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<LanguageDTO>>> GetAllAsync();

        Task<Result<IEnumerable<LanguageDTO>>> GetPagedAsync(int paging = 1, int pageSize = 10);

        Task<Result> UpdateAsync(Language language);

        Task<Result> SoftDeleteAsync(Guid Id);
    }
}
