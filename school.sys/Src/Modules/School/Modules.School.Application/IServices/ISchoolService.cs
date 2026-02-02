using Modules.School.Domain.Entities;
using Modules.School.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result<Schools>> CreateAsync(Schools school);

        Task<Result<Schools>> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Schools>>> GetAllAsync();

        Task<Result<IEnumerable<Schools>>> GetAllAsync(int paging, int pageSize);

        Task<Result<Schools>> UpdateAsync(Schools school);

        Task<Result<Schools>> DeleteAsync(Schools school);
    }
}
