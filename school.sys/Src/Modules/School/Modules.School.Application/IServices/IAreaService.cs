using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;

namespace Modules.School.Application.IServices
{
    public interface IAreaService
    {
        Task<Result<IEnumerable<LocationDTO>>> GetAllByIdAsync(Guid cityId);
    }
}
