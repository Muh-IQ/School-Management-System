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
        public async Task<Result<IEnumerable<CountryDTO>>> GetAsync()
        {
            var result = await repository.GetAsync();

            return result.Count() > 0
                ? Result<IEnumerable<CountryDTO>>.Success(result)
                : Result<IEnumerable<CountryDTO>>.Failure(ErrorType.NotFound , CountryErrors.NotFoundMessage());
        }
    }
}
