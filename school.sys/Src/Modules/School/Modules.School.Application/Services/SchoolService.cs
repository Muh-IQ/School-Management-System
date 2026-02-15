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
        private readonly IGenericRepository<Domain.Entities.School> _Repository;
        private readonly ISchoolRepository _SchoolRepository;

        public SchoolService(IGenericRepository<Domain.Entities.School> repository,ISchoolRepository schoolRepository)
        {
            _Repository = repository;
            _SchoolRepository = schoolRepository;
        }
        private async Task<bool> EmailExists(string Email)
        {
            var exists = await _Repository.AnyAsync(s => s.Email == Email);
            return exists; 
        }
        private async Task<bool> PhoneExists(string Phone)
        {
            var exists = await _Repository.AnyAsync(s => s.Phone == Phone);
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
        
        public async Task<Result> CreateAsync(SchoolAddDTO newSchool)
        {
            var validationResult = await ValidateContactUniquenessAsync(newSchool.Email, newSchool.Phone);
            if (!validationResult.IsSuccess)
                return validationResult;

            var school = SchoolMapper.MapSchoolAddDTOToEntity(newSchool);
            var added = await _Repository.AddAsync(school);

            if (!added)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }
        public async Task<Result<Domain.Entities.School>> GetByIdAsync(Guid Id)
        {
            var school = await _Repository.GetByIdAsync(Id);

            if (school == null)
            {
                return Result<Domain.Entities.School>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(Id));
            }
            return Result<Domain.Entities.School>.Success(school);
        }

        public async Task<Result<SchoolDTO>> GetByIdAsDtoAsync(Guid id)
        {
            var dto = await _SchoolRepository.GetByIdAsDtoAsync(id);
            if (dto is null)
            {
                return Result<SchoolDTO>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            }
            return Result<SchoolDTO>.Success(dto);
        }

        public async Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync(int pageing = 1, int pageSize = 10)
        {
            var School = await _Repository.GetAllAsync(pageing, pageSize);
            if (School == null)
            {
                return Result<IEnumerable<Domain.Entities.School>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }
            return Result<IEnumerable<Domain.Entities.School>>.Success(School);
        }
        public async Task<Result> UpdateAsync(Guid id, SchoolUpdateDTO updatedSchool)
        {
            var exist = await _Repository.GetByIdAsync(id);
            if (exist == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));

            SchoolMapper.MapSchoolUpdateDTOToEntity(updatedSchool, exist);
            var updated = await _Repository.UpdateAsync(exist);

            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var school = await _Repository.GetByIdAsync(id);

            if (school == null)
            {
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            }
            var delete = await _Repository.DeleteAsync(school);

            if (!delete)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }
            return Result.Success();
        }

        public async Task<Result<IEnumerable<SchoolDTO>>> GetAllAsDtoAsync(int paging = 1, int pageSize = 10)
        {
            var dtos = await _SchoolRepository.GetAllAsDtoAsync(paging, pageSize);
            if (dtos == null)
            {
                return Result<IEnumerable<SchoolDTO>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }
            return Result<IEnumerable<SchoolDTO>>.Success(dtos);
        }
    }
}
