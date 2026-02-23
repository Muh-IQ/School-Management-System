using Modules.School.Application.Helpers;
using Modules.School.Application.IServices;
using Modules.School.Application.Mappers;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _SchoolRepository;

        public SchoolService(ISchoolRepository repository)
        {
            _SchoolRepository = repository;
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

        public async Task<Result> SoftDeleteAsync(Guid schoolId)
        {
            var school = await _SchoolRepository.GetByIdAsync(schoolId);

            if (school == null)
                return Result<bool>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(schoolId));
            if (school.IsDeleted)
                return Result<bool>.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());
            if (!school.IsActive)
                return Result<bool>.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());

            school.IsDeleted = true;
            school.IsActive = false;

            var updated = await _SchoolRepository.UpdateAsync(school);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
        public async Task<Result> CreateAsync(SchoolAddCommand newSchool)
        {
            var validationResult = await ValidateContactUniquenessAsync(newSchool.Email, newSchool.Phone);
            if (!validationResult.IsSuccess)
                return validationResult;

            var school = SchoolMapper.MapSchoolAddDTOToEntity(newSchool);
            var added = await _SchoolRepository.AddAsync(school);

            if (!added)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
        public async Task<Result<Domain.Entities.School>> GetByIdAsync(Guid Id)
        {
            var school = await _SchoolRepository.GetByIdAsync(Id);

            if (school == null)
            {
                return Result<Domain.Entities.School>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(Id));
            }
            return Result<Domain.Entities.School>.Success(school);
        }


        public async Task<Result<IEnumerable<Domain.Entities.School>>> GetPagedAsync(int pageing = 1, int pageSize = 10)
        {
            var School = await _SchoolRepository.GetPagedListAsync(pageing, pageSize);
            if (School == null)
            {
                return Result<IEnumerable<Domain.Entities.School>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }
            return Result<IEnumerable<Domain.Entities.School>>.Success(School);
        }
        public async Task<Result> UpdateAsync(Guid id, SchoolUpdateCommand updatedSchool)
        {
            var exist = await _SchoolRepository.GetByIdAsync(id);
            if (exist == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));

            SchoolMapper.MapSchoolUpdateDTOToEntity(updatedSchool, exist);
            var updated = await _SchoolRepository.UpdateAsync(exist);

            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var school = await _SchoolRepository.GetByIdAsync(id);

            if (school == null)
            {
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            }
            var delete = await _SchoolRepository.DeleteAsync(school);

            if (!delete)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }
            return Result.Success();
        }


    }
}
