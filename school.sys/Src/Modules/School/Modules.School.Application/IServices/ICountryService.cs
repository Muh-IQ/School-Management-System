using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.Entities.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices;

public interface ICountryService
{
    Task<Result<IEnumerable<CountryDTO>>> GetAsync();
}

