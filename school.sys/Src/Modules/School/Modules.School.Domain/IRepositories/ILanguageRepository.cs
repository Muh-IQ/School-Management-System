using Modules.School.Domain.DTOs;

namespace Modules.School.Domain.IRepositories;

public interface ILanguageRepository
{
    Task<LanguageDTO?> GetByIdAsync(Guid id);
    Task<IEnumerable<LanguageDTO>> GetAllAsync();
}
