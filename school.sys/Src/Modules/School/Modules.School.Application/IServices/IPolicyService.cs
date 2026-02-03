using Modules.School.Domain.Entities;
using Modules.School.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface IPolicyService
    {
        Task<Result> CreateAsync(Policy policy);

        Task<Result> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Policy>>> GetAllAsync();

        Task<Result<IEnumerable<Policy>>> GetAllAsync(int paging=1, int pageSize=10);

        Task<Result> UpdateAsync(Policy policy);

        Task<Result> DeleteAsync(Guid Id);
    }
}
