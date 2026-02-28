using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class LanguageService(ILanguageRepository repository) : ILanguageService
    {
        public async Task<Result<LanguageDTO>> GetByIdAsync(Guid id)
        {
            var lang = await repository.GetByIdAsync(id);
            return lang != null ?
                Result<LanguageDTO>.Success(lang) :
                Result<LanguageDTO>.Failure(ErrorType.NotFound, "Language Not Found.");
        }
        public async Task<Result<IEnumerable<LanguageDTO>>> GetAllAsync()
        {
            var languages = await repository.GetAllAsync();
            return languages != null && languages.Count() > 0 ?
                Result<IEnumerable<LanguageDTO>>.Success(languages) :
                Result<IEnumerable<LanguageDTO>>.Failure(ErrorType.NotFound, "Languages Not Found.");
        }
    }
}
