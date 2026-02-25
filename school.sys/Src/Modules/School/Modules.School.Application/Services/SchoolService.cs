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
        public SchoolService(ISchoolRepository repository, IPolicyRepository policyRepository)
        {
            _SchoolRepository = repository;
            _PolicyRepository = policyRepository;
        }
       
        /////////////////////////

        private bool PolicyInfoProvided(SchoolAddCommand dto)
        {
            return !string.IsNullOrWhiteSpace(dto.PolicyTitle) &&
                   !string.IsNullOrWhiteSpace(dto.PolicyType) &&
                   !string.IsNullOrWhiteSpace(dto.PolicyDescription);
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

        ///////////////////



        public async Task<Result> SoftDeleteAsync(Guid schoolId)
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
            SchoolMapper _Mapper= new SchoolMapper();
            var validationResult = await ValidateContactUniquenessAsync(newSchool.Email, newSchool.Phone);
            if (!validationResult.IsSuccess)
                return validationResult;
            Policy? newPolicy = null;
            Guid policyId;

            if (PolicyInfoProvided(newSchool))
            {
                newPolicy =_Mapper.MapSchoolAddPolicyoEntityPolicy(newPolicy.Title, newPolicy.Description);
                await _PolicyRepository.AddAsync(newPolicy);
                policyId = newPolicy.Id;
            }
            else
            {
                policyId = await _PolicyRepository.GetDefaultPolicyIdAsync();
            }
            var school =_Mapper.MapSchoolAddDTOToEntity(newSchool, policyId);

            var added = await _SchoolRepository.AddAsync(school);

            if (!added)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

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
    }
}
