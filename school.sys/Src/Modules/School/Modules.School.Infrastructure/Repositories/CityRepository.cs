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
    internal class CityRepository(SchoolDbContext context) : ICityRepository
    {
        public async Task<IEnumerable<LocationDTO>> GetByIdAsync(Guid countryId)
        {
            return context.Cities
              .Where(c => c.CountryId == countryId && c.IsActive)
              .Select(c => new LocationDTO
              {
                  Id = c.Id,
                  Name = c.Name
              }).ToList();
        }
    }
}
