using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Infrastructure.Repositories
{
    internal class CountryRepository(SchoolDbContext context) : ICountryRepository
    {
        public async Task<IEnumerable<CountryDTO>> GetAsync()
        {
            return context.Countries.Select(c => new CountryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
