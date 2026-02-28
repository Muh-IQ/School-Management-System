using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> _Repository;

        public LanguageService(IGenericRepository<Language> repository)
        {
            _Repository = repository;
        }
        public async Task<Result> CreateAsync(Language language)
        {
            var exist = await _Repository.AnyAsync(s => s.Name == language.Name);

            if (exist)
            {
                return Result.Failure(ErrorType.Conflict, "Language Already Exists.");
            }

            var added = await _Repository.AddAsync(language);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, "Faild To Create Language.");
            }

            return Result.Success();
        }

        public async Task<Result> GetByIdAsync(Guid Id)
        {
            var lang = await _Repository.GetByIdAsync(Id);

            if (lang == null)
            {
                return Result.Failure(ErrorType.NotFound, "Language Not Found.");
            }

            return Result.Success();
        }

        public async Task<Result<IEnumerable<Language>>> GetAllAsync()
        {
            var lang = await _Repository.GetAllAsync();

            if (lang == null)
            {
                return Result<IEnumerable<Language>>.Failure(ErrorType.NotFound, "Schools Not Found.");
            }

            return Result<IEnumerable<Language>>.Success(lang);
        }

        public async Task<Result<IEnumerable<Language>>> GetPagedAsync(int pageing = 1, int pageSize = 10)
        {
            var lang = await _Repository.GetPagedAsync(pageing, pageSize);

            if (lang == null)
            {
                return Result<IEnumerable<Language>>.Failure(ErrorType.NotFound, "Language Not Found");
            }

            return Result<IEnumerable<Language>>.Success(lang);
        }

        public async Task<Result> UpdateAsync(Language language)
        {
            var exist = await _Repository.AnyAsync(s => s.Id == language.Id);

            if (!exist)
            {
                return Result.Failure(ErrorType.NotFound, $"Language With ID {language.Id} Not Found.");
            }

            var updated = await _Repository.UpdateAsync(language);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, "Updated Failed.");
            }

            return Result.Success();
        }
        public async Task<Result> SoftDeleteAsync(Guid languageId)
        {
            var language = await _Repository.GetByIdAsync(languageId);
            if (language == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(languageId));
            if (language.IsDeleted)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());
            if (!language.IsActive)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());

            language.IsDeleted = true;
            language.IsActive = false;

            var updated = await _Repository.UpdateAsync(language);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

    }
}
