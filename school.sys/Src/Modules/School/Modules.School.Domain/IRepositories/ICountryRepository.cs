using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.IRepositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryDTO>> GetAsync();

    }
}
