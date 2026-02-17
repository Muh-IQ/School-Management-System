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
        public async Task<IEnumerable<LocationDTO>> GetAllAsync()
        {
            return context.Countries
                .Where(c => c.IsActive)
                .Select(c => new LocationDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
