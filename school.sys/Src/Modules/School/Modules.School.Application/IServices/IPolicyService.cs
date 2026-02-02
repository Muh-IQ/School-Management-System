using Modules.School.Domain.Entities;
using Modules.School.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface IPolicyService
    {
        Task<Result<Policies>> CreateAsync(Policies policy);

        Task<Result<Policies>> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Policies>>> GetAllAsync();

        Task<Result<IEnumerable<Policies>>> GetAllAsync(int paging, int pageSize);

        Task<Result<Policies>> UpdateAsync(Policies policy);

        Task<Result<Policies>> DeleteAsync(Policies policy);
    }
}
