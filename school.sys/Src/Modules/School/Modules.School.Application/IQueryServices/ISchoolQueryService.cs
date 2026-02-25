using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.IQueryServices
{
    public interface ISchoolQueryService
    {
        Task<Result<SchoolDetailsDTO?>> GetByIdAsDtoAsync(Guid id);
        Task<Result<IEnumerable<SchoolListItemDTO>>> GetPagedAsync(int pageNumber = 1, int pageSize = 10);


    }
}
