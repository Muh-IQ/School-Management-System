using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    public class CityService(ICityRepository repository) : ICityService
    {
        public async Task<Result<IEnumerable<LocationDTO>>> GetAllByIdAsync(Guid countryID)
        {
           var cities = await repository.GetAllByIdAsync(countryID);
            return cities.Count() > 1 ?
                Result<IEnumerable<LocationDTO>>.Success(await repository.GetAllByIdAsync(countryID)) :
                Result<IEnumerable<LocationDTO>>.Failure(ErrorType.NotFound, "No cities found for the given country ID.");
        }
    }
}
