using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class LanguageService : ILanguageService
    {
        private const int MaxPageSize = 100;
        private readonly IGenericRepository<Language> _Repository;
        private readonly ILanguageRepository _LanguageRepository;
        private readonly IGenericRepository<Domain.Entities.School> _SchoolRepository;

        public LanguageService(
            IGenericRepository<Language> repository,
            ILanguageRepository languageRepository,
            IGenericRepository<Domain.Entities.School> schoolRepository)
        {
            _Repository = repository;
            _LanguageRepository = languageRepository;
            _SchoolRepository = schoolRepository;
        }

        public async Task<Result> CreateAsync(Language language)
        {
            if (language == null)
                return Result.Failure(ErrorType.BadRequest, UserErrors.BadRequestMessage());

            if (string.IsNullOrWhiteSpace(language.Name))
                return Result.Failure(ErrorType.Validation, LanguageErrors.NameRequired());

            if (string.IsNullOrWhiteSpace(language.Code))
                return Result.Failure(ErrorType.Validation, LanguageErrors.CodeRequired());

            var nameExists = await _Repository.AnyAsync(l => l.Name == language.Name.Trim());
            if (nameExists)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.NameAlreadyExists());

            var codeExists = await _Repository.AnyAsync(l => l.Code == language.Code.Trim());
            if (codeExists)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.CodeAlreadyExists());

            if (language.Id == Guid.Empty)
                language.Id = Guid.NewGuid();
            language.Name = language.Name.Trim();
            language.Code = language.Code.Trim();
            language.IsActive = true;
            language.IsDeleted = false;

            var added = await _Repository.AddAsync(language);
            if (!added)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result<LanguageDTO>> GetByIdAsync(Guid id)
        {
            var lang = await _LanguageRepository.GetByIdAsync(id);
            if (lang == null)
                return Result<LanguageDTO>.Failure(ErrorType.NotFound, LanguageErrors.NotFoundMessage(id));
            return Result<LanguageDTO>.Success(lang);
        }
        public async Task<Result<IEnumerable<LanguageDTO>>> GetAllAsync()
        {
            var lang = await _LanguageRepository.GetAllAsync();
            if (lang == null)
                return Result<IEnumerable<LanguageDTO>>.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            return Result<IEnumerable<LanguageDTO>>.Success(lang);
        }

        public async Task<Result<IEnumerable<LanguageDTO>>> GetPagedAsync(int paging = 1, int pageSize = 10)
        {
            if (paging < 1 || pageSize < 1 || pageSize > MaxPageSize)
                return Result<IEnumerable<LanguageDTO>>.Failure(ErrorType.Validation, LanguageErrors.InvalidPaging());

            var lang = await _LanguageRepository.GetPagedAsync(paging, pageSize);
            if (lang == null)
                return Result<IEnumerable<LanguageDTO>>.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            return Result<IEnumerable<LanguageDTO>>.Success(lang);
        }

        public async Task<Result> UpdateAsync(Language language)
        {
            if (language == null)
                return Result.Failure(ErrorType.BadRequest, UserErrors.BadRequestMessage());

            if (language.Id == Guid.Empty)
                return Result.Failure(ErrorType.Validation, LanguageErrors.NotFoundMessage(language.Id));

            if (string.IsNullOrWhiteSpace(language.Name))
                return Result.Failure(ErrorType.Validation, LanguageErrors.NameRequired());

            if (string.IsNullOrWhiteSpace(language.Code))
                return Result.Failure(ErrorType.Validation, LanguageErrors.CodeRequired());

            var existing = await _Repository.GetByIdAsync(language.Id);
            if (existing == null)
                return Result.Failure(ErrorType.NotFound, LanguageErrors.NotFoundMessage(language.Id));

            if (existing.IsDeleted)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.CannotUpdateDeleted());

            var nameExists = await _Repository.AnyAsync(l => l.Name == language.Name.Trim() && l.Id != language.Id);
            if (nameExists)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.NameAlreadyExists());

            var codeExists = await _Repository.AnyAsync(l => l.Code == language.Code.Trim() && l.Id != language.Id);
            if (codeExists)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.CodeAlreadyExists());

            existing.Name = language.Name.Trim();
            existing.Code = language.Code.Trim();

            var updated = await _Repository.UpdateAsync(existing);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
        public async Task<Result> SoftDeleteAsync(Guid languageId)
        {
            var language = await _Repository.GetByIdAsync(languageId);
            if (language == null)
                return Result.Failure(ErrorType.NotFound, LanguageErrors.NotFoundMessage(languageId));

            if (language.IsDeleted)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.AlreadyDeleted());

            if (!language.IsActive)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());

            var inUseBySchool = await _SchoolRepository.AnyAsync(s => s.LanguageId == languageId && !s.IsDeleted);
            if (inUseBySchool)
                return Result.Failure(ErrorType.Conflict, LanguageErrors.CannotDeleteInUse());

            language.IsDeleted = true;
            language.IsActive = false;

            var updated = await _Repository.UpdateAsync(language);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
    }
}
