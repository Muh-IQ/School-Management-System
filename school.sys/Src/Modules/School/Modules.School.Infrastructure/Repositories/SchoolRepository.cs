using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    LanguageCode = s.Language.Code,
                    LanguageName = s.Language.Name,
                    PolicyTitle = s.Policy.Title,
                    PolicyDescription = s.Policy.Description,
                    PolicyType = s.Policy.PolicyType       
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SchoolListItemDTO>> GetPagedAsDtoAsync(int paging = 1, int pageSize = 10)
        {
            return await _dbSet
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Name)
                .Skip((paging - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new SchoolListItemDTO
                {
<<<<<<< HEAD
                    Id = s.Id,  
=======
                    Id = s.Id,
>>>>>>> f7f4a76 (Refactor arch)
                    Name = s.Name,
                    LanguageCode = s.Language.Code,
                    PolicyTitle = s.Policy.Title,
                   
                })
                .ToListAsync();
        }
    }
}
