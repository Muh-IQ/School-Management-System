using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories
{
    internal class AreaRepository(SchoolDbContext context) : IAreaRepository
    {
        public async Task<IEnumerable<LocationDTO>> GetByIdAsync(Guid countryId, Guid cityId)
        {
            return await context.Areas
                .Where(a => a.City.CountryId == countryId && a.CityId == cityId && a.IsActive)
                .Select(a => new LocationDTO
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
    }
}
