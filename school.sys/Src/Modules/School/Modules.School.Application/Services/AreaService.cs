using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class AreaService(IAreaRepository _areaRepository) : IAreaService
    {
        public async Task<Result<IEnumerable<LocationDTO>>> GetAllByIdAsync(Guid countryId,Guid cityId)
        {
            if (cityId == Guid.Empty)
            {
                return Result<IEnumerable<LocationDTO>>.Failure(ErrorType.Validation, UserErrors.ValidationMessage("cityID"));
            }
            var areas = await _areaRepository.GetByIdAsync(countryId,cityId);

            if (!areas.Any())
            {
                return Result<IEnumerable<LocationDTO>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }
            
            return Result<IEnumerable<LocationDTO>>.Success(areas);
        }
    }
}
