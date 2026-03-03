using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories
{
    public class SchoolRepository : GenericRepository<Domain.Entities.School>, ISchoolRepository
    {
        public SchoolRepository(SchoolDbContext context) : base(context)
        {
        }

        public async Task<SchoolDetailsDTO?> GetByIdAsDtoAsync(Guid id)
        {
            return await _dbSet
                .Where(s => s.Id == id && !s.IsDeleted)
                .Select(s => new SchoolDetailsDTO
                {
                    Email = s.Email,
                    Phone = s.Phone,
                    LanguageName = s.Language.Name,
                    PolicyDescription = s.Policy.Description,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SchoolListItemDTO>> GetPagedAsDtoAsync(int paging =1, int pageSize =10)
        {
            return await _dbSet
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Name)
                .Skip((paging - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new SchoolListItemDTO
                {
                    Id = s.Id,  
                    Name = s.Name,
                    LanguageCode = s.Language.Code,
                    PolicyTitle = s.Policy.Title,
                    CountryName= s.Country.Name,
                    sanitizeName= s.sanitizeName
                   
                })
                .ToListAsync();
        }
    }
}
