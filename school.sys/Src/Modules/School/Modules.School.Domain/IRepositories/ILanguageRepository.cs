using Modules.School.Domain.DTOs;

namespace Modules.School.Domain.IRepositories;

public interface ILanguageRepository
{
    Task<IEnumerable<LanguageDTO>> GetAllAsync();
}
