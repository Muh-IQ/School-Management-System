using Modules.School.Application.IQueryServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.QueryServices
{
    public class SchoolQueryService(IGenericRepository<Domain.Entities.School> _schoolRepository) :ISchoolQueryService
    {
        public async Task<Result<SchoolDetailsDTO?>> GetByIdAsDtoAsync(Guid id)
        {
            var school = await _schoolRepository.GetByIdAsync(id);
            if (school == null)
            {
                return Result<SchoolDetailsDTO?>.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage());
            }

            var schoolDto = new SchoolDetailsDTO
            {
                Name = school.Name,
                Email = school.Email,
                Phone = school.Phone,
                LanguageCode = school.Language.Code,
                LanguageName = school.Language.Name,
                PolicyTitle = school.Policy.Title,
                PolicyDescription = school.Policy.Description,
            };

            return Result<SchoolDetailsDTO?>.Success(schoolDto);
        }

        public async Task<Result<IEnumerable<SchoolDetailsDTO>>> GetPagedAsDtoAsync(int paging = 1, int pageSize = 10)
        {
            if (paging < 1) paging = 1;
            if (pageSize < 1) pageSize = 10;

            try
            {
                var schools = await _schoolRepository.GetPagedListAsync(paging, pageSize);

                // استخدم IQueryable من GenericRepo
                var query =await _schoolRepository.GetPagedListAsync(paging, pageSize)
                    .Where(s => !s.IsDeleted)
                    .OrderBy(s => s.Name)
                    .Skip((paging - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new SchoolDetailsDTO
                    {
                        Name = s.Name,
                        Email = s.Email,
                        Phone = s.Phone,
                        LanguageCode = s.Language.Code,
                        LanguageName = s.Language.Name,
                        PolicyTitle = s.Policy.Title,
                        PolicyDescription = s.Policy.Description,
                        PolicyType = s.Policy.PolicyType
                    });

                // AsNoTracking لتقليل استهلاك الذاكرة لأننا قراءة فقط
                var schools = await query.AsNoTracking().ToListAsync();

                return Result.Success<IEnumerable<SchoolDetailsDTO>>(schools);
            }
            catch (Exception ex)
            {
                // Logging هنا إذا مطلوب
                return Result.Failure<IEnumerable<SchoolDetailsDTO>>(ErrorType.InternalServerError, "Failed to get schools.");
            }
        }
    }
}
