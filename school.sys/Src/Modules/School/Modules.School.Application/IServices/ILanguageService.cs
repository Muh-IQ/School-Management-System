using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;

namespace Modules.School.Application.IServices
{
    public interface ILanguageService
    {
        Task<Result<LanguageDTO>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<LanguageDTO>>> GetAllAsync();
    }
}
