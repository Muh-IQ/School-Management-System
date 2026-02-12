using Modules.School.Application.Common.DTOs;
using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using System.Text.RegularExpressions;

namespace Modules.School.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IGenericRepository<Domain.Entities.School> _Repository;

        public SchoolService(IGenericRepository<Domain.Entities.School> repository)
        {
            _Repository = repository;
        }
        private string GenerateSlug(string Text)
        {
            if (string.IsNullOrWhiteSpace(Text))
                return string.Empty;
            string str = Text.ToLowerInvariant();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"-+", "-");
            str = str.Trim('-');
            return str;
        }
        private  Domain.Entities.School MapSchoolDTOToEntity(SchoolDTO schoolDTO)
        {
            var s = new Domain.Entities.School
            {
                Name = schoolDTO.Name,
                sanitizeName = GenerateSlug(schoolDTO.Name),
                Email = schoolDTO.Email,
                Phone = schoolDTO.Phone,
                Language = new Domain.Entities.Language
                {
                    Code = schoolDTO.LanguageCode,
                    Name = schoolDTO.LanguageName,
                    IsActive = true,
                    IsDeleted = false
                },
                Policy = new Domain.Entities.Policy
                {
                    Title = schoolDTO.PolicyTitle,
                    sanitizeName = GenerateSlug(schoolDTO.PolicyTitle),
                    Description = schoolDTO.PolicyDescription,
                    PolicyType = schoolDTO.PolicyType,
                    IsActive = true,
                    IsDeleted = false

                },
                IsActive = true,
                IsDeleted = false,
                TimeZone = DateTime.UtcNow.ToString("zzz")


            };
            return s;
        }

        public async Task<Result> CreateAsync(SchoolDTO newSchool)
        {
            var exist = await _Repository.AnyAsync(s => s.Email == newSchool.Email
            || s.Phone == newSchool.Phone);

            if (exist)
            {
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage(ExistsName: newSchool.Name));
            }

            var school= MapSchoolDTOToEntity(newSchool);
            var added = await _Repository.AddAsync(school);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }

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

        public async Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync()
        {
            var School = await _Repository.GetAllAsync();
            if (School == null)
            {
                return Result<IEnumerable<Domain.Entities.School>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }
            return Result<IEnumerable<Domain.Entities.School>>.Success(School);
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

        public async Task<Result> UpdateAsync(Guid id, SchoolDTO updatedSchool)
        {
            var exist = await _Repository.GetByIdAsync(id);

            if (exist == null)
            {
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            }

            var s = MapSchoolDTOToEntity(updatedSchool);

            exist.Name = s.Name;
            exist.sanitizeName = s.sanitizeName;
            exist.Email = s.Email;
            exist.Phone = s.Phone;
            exist.Language = s.Language;
            exist.Policy = s.Policy;
            var updated = await _Repository.UpdateAsync(exist);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }

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

    }
}
