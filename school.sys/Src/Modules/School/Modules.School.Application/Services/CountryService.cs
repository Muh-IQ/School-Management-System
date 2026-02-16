using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    public class CountryService(ICountryRepository repository) : ICountryService
    {
        public async Task<Result<IEnumerable<LocationDTO>>> GetAsync()
        {
            var result = await repository.GetAllAsync();

            return result.Count() > 0
                ? Result<IEnumerable<LocationDTO>>.Success(result)
                : Result<IEnumerable<LocationDTO>>.Failure(ErrorType.NotFound , CountryErrors.NotFoundMessage());
        }
    }
}
