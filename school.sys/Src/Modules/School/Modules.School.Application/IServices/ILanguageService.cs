using Modules.School.Domain.Entities;
using Modules.School.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{

    public interface ILanguageService
    {
        Task<Result<Languages>> CreateAsync(Languages language);

        Task<Result<Languages>> GetByIdAsync(Guid id);

        Task<Result<IEnumerable<Languages>>> GetAllAsync();

        Task<Result<IEnumerable<Languages>>> GetAllAsync(int paging, int pageSize);

        Task<Result<Languages>> UpdateAsync(Languages language);

        Task<Result<Languages>> DeleteAsync(Languages language);
    }
}
