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
    public class SchoolQueryService(ISchoolRepository _schoolRepository) :ISchoolQueryService
    {
        public async Task<Result<IEnumerable<SchoolListItemDTO>>> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            var pagedSchools = await _schoolRepository.GetPagedAsDtoAsync(pageNumber, pageSize);

            return Result<IEnumerable<SchoolListItemDTO>>.Success(pagedSchools);
        }
        public async Task<Result<SchoolDetailsDTO>> GetByIdAsDtoAsync(Guid id)
        {
            var school = await _schoolRepository.GetByIdAsDtoAsync(id);
            if (school == null)
                return Result<SchoolDetailsDTO>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(id));
            return Result<SchoolDetailsDTO>.Success(school);

        }


    }
}
