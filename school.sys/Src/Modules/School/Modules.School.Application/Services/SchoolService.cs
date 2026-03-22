using Modules.School.Application.Helpers;
using Modules.School.Application.IServices;
using Modules.School.Application.Mappers;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.Entities.Place;
using Modules.School.Domain.IRepositories;
using Modules.School.Domain.IThirdPartyServices;

namespace Modules.School.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _SchoolRepository;
        private readonly IPolicyRepository _PolicyRepository;
        private readonly IGenericRepository<Language> _LanguageRepository;
        private readonly ICacheService _cacheService;
        private readonly IGenericRepository<Country> _CountryRepository;
        private readonly IGenericRepository<City> _CityRepository;
        private readonly IGenericRepository<Area> _AreaRepository;
        private readonly ITimeProvider _timeProvider;
        public SchoolService(ISchoolRepository repository, IPolicyRepository policyRepository,
            IGenericRepository<Language> languageRepository, ICacheService cacheService,
            IGenericRepository<Country> countryRepository, IGenericRepository<City> cityRepository,
            IGenericRepository<Area> areaRepository, ITimeProvider timeProvider)
        {
            _SchoolRepository = repository;
            _PolicyRepository = policyRepository;
            _LanguageRepository = languageRepository;
            this._cacheService = cacheService;
            _CountryRepository = countryRepository;
            _CityRepository = cityRepository;
            _AreaRepository = areaRepository;
            _timeProvider = timeProvider;
        }

        /////////////////////////

        private Result ValidatePolicyInfo(string policyTitle, string policyDescription)
        {
            bool hasTitle = !string.IsNullOrWhiteSpace(policyTitle);
            bool hasDescription = !string.IsNullOrWhiteSpace(policyDescription);

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

        private async Task<Result> CheckLocation(Guid CountryId,Guid CityId,Guid AreaId)
        {
            if(!await _CountryRepository.AnyAsync(c => c.Id == CountryId))
                return Result.Failure(ErrorType.NotFound, CountryErrors.NotFoundMessage(CountryId));
            if(!await _CityRepository.AnyAsync(c => c.CountryId == CountryId && c.Id == CityId ))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(CityId));
            if(!await _AreaRepository.AnyAsync(a => a.CityId == CityId && a.Id == AreaId))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(AreaId));
            return Result.Success();
        }

        private  bool IsSchoolDataUnchanged(SchoolUpdateCommand schoolUpdateCommand,Domain.Entities.School school)
        {
            return
                school.Email == schoolUpdateCommand.Email &&
                school.Phone == schoolUpdateCommand.Phone &&
                school.Name == schoolUpdateCommand.Name &&
                school.LanguageId == schoolUpdateCommand.LanguageId &&
                school.CountryId == schoolUpdateCommand.CountryId &&
                school.CityId == schoolUpdateCommand.CityId &&
                school.AreaId == schoolUpdateCommand.AreaId;
        }
        private bool IsPolicyDataUnchanged(SchoolUpdateCommand schoolUpdateCommand, Domain.Entities.Policy policy)
        {
            return
                policy.Title == schoolUpdateCommand.PolicyTitle &&
                policy.Description == schoolUpdateCommand.PolicyDescription;
        }

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

            var locationValidation = await CheckLocation(newSchool.CountryId, newSchool.CityId, newSchool.AreaId);
            if (!locationValidation.IsSuccess)
                return locationValidation;

            SchoolMapper mapper = new SchoolMapper();
            
            var validationResult = await ValidateContactUniquenessAsync(newSchool.Email,newSchool.Phone);

            if (!validationResult.IsSuccess)
                return validationResult;

            var policyValidation = ValidatePolicyInfo(newSchool.PolicyTitle, newSchool.PolicyDescription);

            if (!policyValidation.IsSuccess)
                return policyValidation;

            Guid policyId;
            bool hasPolicy =!string.IsNullOrWhiteSpace(newSchool.PolicyTitle);

            if (hasPolicy)
            {
                var newPolicy = mapper.MapSchoolAddDTOToEntityPolicy(newSchool.PolicyTitle,newSchool.PolicyDescription);
                newPolicy.sanitizeName=TextHelper.SlugGenerate(newSchool.Name);
                newPolicy.CreateAt=_timeProvider.UtcNow;
                newPolicy.UpdateAt = null;

                await _PolicyRepository.AddAsync(newPolicy);
                policyId = newPolicy.Id;
            }
            else
            {
                policyId = await _PolicyRepository.GetDefaultPolicyIdAsync();
            }

            var school = mapper.MapSchoolAddDTOToEntity(newSchool, policyId);
            school.sanitizeName=TextHelper.SlugGenerate(school.Name);
            school.CreateAt=_timeProvider.UtcNow;
            school.UpdateAt=null;
            var added = await _SchoolRepository.AddAsync(school);

            if (!added)
                return Result.Failure(ErrorType.InternalServerError,UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Guid id, SchoolUpdateCommand updatedSchool)
        {
            //check policy info
            if (string.IsNullOrEmpty(updatedSchool.PolicyTitle) || string.IsNullOrEmpty(updatedSchool.PolicyDescription))
            {
                return Result.Failure(ErrorType.BadRequest, "Both PolicyTitle and PolicyDescription should be provided together.");
            }

            //check contact
            var validationResult = await ValidateContactUniquenessAsync(updatedSchool.Email, updatedSchool.Phone);
            if (!validationResult.IsSuccess)
                return validationResult;


            //check language
            if (!await LanguageExists(updatedSchool.LanguageId))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());

            //check location
            var locationValidation = await CheckLocation(updatedSchool.CountryId, updatedSchool.CityId, updatedSchool.AreaId);
            if (!locationValidation.IsSuccess)
                return locationValidation;


            var exist = await _SchoolRepository.GetWithPolicyAsync(id);

            //check school
            if (exist == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));

            if(IsSchoolDataUnchanged(updatedSchool, exist) && IsPolicyDataUnchanged(updatedSchool,exist.Policy))
            {
                return Result.Success();
            }

            Policy UpdatePolicy;
            SchoolMapper _Mapper = new SchoolMapper();

            if (IsPolicyDataUnchanged(updatedSchool,exist.Policy))
            {
                    UpdatePolicy = exist.Policy;
            }
            else if(exist.PolicyId == await _PolicyRepository.GetDefaultPolicyIdAsync())
            {
                exist.UpdateAt = _timeProvider.UtcNow;
                UpdatePolicy = _Mapper.MapSchoolAddDTOToEntityPolicy(updatedSchool.PolicyTitle, updatedSchool.PolicyDescription);
                UpdatePolicy.sanitizeName = TextHelper.SlugGenerate(updatedSchool.PolicyTitle);
                UpdatePolicy.CreateAt = _timeProvider.UtcNow;
                UpdatePolicy.UpdateAt = null;
                await _PolicyRepository.AddAsync(UpdatePolicy);

            }
            else
            {
                UpdatePolicy = exist.Policy;
                UpdatePolicy.Title = updatedSchool.PolicyTitle;
                UpdatePolicy.Description = updatedSchool.PolicyDescription;
                UpdatePolicy.sanitizeName = TextHelper.SlugGenerate(updatedSchool.PolicyTitle);
                UpdatePolicy.UpdateAt= _timeProvider.UtcNow;

            }

            if(!IsSchoolDataUnchanged(updatedSchool,exist))
            {
                exist.UpdateAt = _timeProvider.UtcNow;
            }

            _Mapper.MapSchoolUpdateDTOToEntity(updatedSchool, exist, UpdatePolicy);

            exist.sanitizeName=TextHelper.SlugGenerate(exist.Name);
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

        public async Task<Result<IEnumerable<SchoolListItemDTO>>> GetPagedAsync(int pageNumber = 1, int pageSize = 100)
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
