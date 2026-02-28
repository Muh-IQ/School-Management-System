using Modules.School.Application.Helpers;
using Modules.School.Application.IServices;
using Modules.School.Application.Mappers;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _SchoolRepository;
        private readonly IPolicyRepository _PolicyRepository;
        private readonly IGenericRepository<Language> _LanguageRepository;
        private readonly ICacheService _cacheService;
        public SchoolService(ISchoolRepository repository, IPolicyRepository policyRepository,
            IGenericRepository<Language> languageRepository, ICacheService cacheService)
        {
            _SchoolRepository = repository;
            _PolicyRepository = policyRepository;
            _LanguageRepository = languageRepository;
            this._cacheService = cacheService;
        }

        /////////////////////////

        private Result ValidatePolicyInfo(SchoolAddCommand dto)
        {
            bool hasTitle = !string.IsNullOrWhiteSpace(dto.PolicyTitle);
            bool hasDescription = !string.IsNullOrWhiteSpace(dto.PolicyDescription);

            if (hasTitle != hasDescription)
            {
                return Result.Failure(ErrorType.BadRequest, "Both PolicyTitle and PolicyDescription should be provided together or both should be null/empty.");
            }

            return Result.Success();
        }

        private async Task<bool> EmailExists(string Email)
        {
            var exists = await _SchoolRepository.AnyAsync(s => s.Email == Email);
            return exists; 
        }
        private async Task<bool> PhoneExists(string Phone)
        {
            var exists = await _SchoolRepository.AnyAsync(s => s.Phone == Phone);
            return exists;
        }
        private async Task<Result> ValidateContactUniquenessAsync(string Email,string Phone)
        {
            if(await EmailExists(Email))
            {
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage(ExistsEmail: Email));
            }
            else if(await PhoneExists(Phone))
            {
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage(ExistsPhone: Phone));
            }

            return Result.Success();
        }
        private async Task<bool> LanguageExists(Guid id)
        {
            var exists = await _LanguageRepository.AnyAsync(l => l.Id == id);
            return exists;
        }

        ///////////////////
        public async Task<Result> DeleteAsync(Guid schoolId)
        {
            var school = await _SchoolRepository.GetByIdAsync(schoolId);
            if (school == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(schoolId));
            if (school.IsDeleted)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());
            if (!school.IsActive)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());

            school.IsDeleted = true;
            school.IsActive = false;

            var updated = await _SchoolRepository.UpdateAsync(school);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
        public async Task<Result> CreateAsync(SchoolAddCommand newSchool)
        {
            if (!await LanguageExists(newSchool.LanguageId))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());

            SchoolMapper mapper = new SchoolMapper();
            
            var validationResult = await ValidateContactUniquenessAsync(newSchool.Email,newSchool.Phone);

            if (!validationResult.IsSuccess)
                return validationResult;

            var policyValidation = ValidatePolicyInfo(newSchool);

            if (!policyValidation.IsSuccess)
                return policyValidation;

            Guid policyId;
            bool hasPolicy =!string.IsNullOrWhiteSpace(newSchool.PolicyTitle);

            if (hasPolicy)
            {
                var newPolicy = mapper.MapSchoolAddDTOToEntityPolicy(newSchool.PolicyTitle,newSchool.PolicyDescription);
                newPolicy.sanitizeName=TextHelper.SlugGenerate(newSchool.Name);

                await _PolicyRepository.AddAsync(newPolicy);
                policyId = newPolicy.Id;
            }
            else
            {
                policyId = await _PolicyRepository.GetDefaultPolicyIdAsync();
            }

            var school = mapper.MapSchoolAddDTOToEntity(newSchool, policyId);
            school.sanitizeName=TextHelper.SlugGenerate(school.Name);

            var added = await _SchoolRepository.AddAsync(school);

            if (!added)
                return Result.Failure(ErrorType.InternalServerError,UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Guid id, SchoolUpdateCommand updatedSchool)
        {
            SchoolMapper _Mapper = new SchoolMapper();
            var exist = await _SchoolRepository.GetByIdAsync(id);
            if (exist == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));

            _Mapper.MapSchoolUpdateDTOToEntity(updatedSchool, exist);
            var updated = await _SchoolRepository.UpdateAsync(exist);

            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result> SetActiveStatusAsync(Guid schoolId, bool isActive)
        {
            var result =await _SchoolRepository.GetByIdAsync(schoolId);
            if (result == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(schoolId));
            if (result.IsActive==isActive)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());
            result.IsActive = isActive; 
            var updated = await _SchoolRepository.UpdateAsync(result);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            return Result.Success();
        }

        public async Task<Result<IEnumerable<SchoolListItemDTO>>> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {

            string cacheKey = $"schools_{pageNumber}_{pageSize}";

            var data = await _cacheService.GetOrCreateAsync(
                cacheKey,
                () => _SchoolRepository.GetPagedAsDtoAsync(pageNumber, pageSize),
                TimeSpan.FromMinutes(15)
            );

            return Result<IEnumerable<SchoolListItemDTO>>.Success(data);
        }


        public async Task<Result<SchoolDetailsDTO>> GetByIdAsync(Guid id)
        {
            var school = await _SchoolRepository.GetByIdAsDtoAsync(id);
            if (school == null)
                return Result<SchoolDetailsDTO>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            return Result<SchoolDetailsDTO>.Success(school);

        }
    }
}
