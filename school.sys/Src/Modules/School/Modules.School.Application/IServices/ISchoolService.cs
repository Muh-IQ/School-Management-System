using Modules.School.Domain.Entities;
using Modules.School.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface ISchoolService
    {
        Task<Result> CreateAsync(SChool school);

        Task<Result> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<SChool>>> GetAllAsync();

        Task<Result<IEnumerable<SChool>>> GetAllAsync(int paging=1, int pageSize=10);

        Task<Result> UpdateAsync(SChool school);

        Task<Result> DeleteAsync(Guid Id);
    }
}
