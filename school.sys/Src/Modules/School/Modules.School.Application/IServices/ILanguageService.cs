using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Entities;

namespace Modules.School.Application.IServices
{

    public interface ILanguageService
    {
        Task<Result> CreateAsync(Language language);

        Task<Result> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Language>>> GetAllAsync();

        Task<Result<IEnumerable<Language>>> GetAllAsync(int paging = 1, int pageSize = 10);

        Task<Result> UpdateAsync(Language language);

        Task<Result> DeleteAsync(Guid Id);
    }
}
