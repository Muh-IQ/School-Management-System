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
    public class SchoolRepository(SchoolDbContext context) : ISchoolRepository
    {
        public async Task<SchoolDTO?> GetByIdAsDtoAsync(Guid id)
        {
            return await context.Schools
                .Where(s => s.Id == id && !s.IsDeleted)
                .Select(s => new SchoolDTO
                {
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
        public async Task<IEnumerable<Domain.Entities.School>> GetActiveSchoolsAsync()
        {
            return await context.Schools.Where(s=>s.IsActive && !s.IsDeleted).ToListAsync();
        }
        public async Task<IEnumerable<Domain.Entities.School>> GetByLanguageAsync(Guid languageId)
        {
            return await context.Schools.Where(s=>s.LanguageId==languageId&&
                !s.IsDeleted && s.IsActive).ToListAsync();
        }
        public async Task<IEnumerable<Domain.Entities.School>> GetByPolicyAsync(Guid policyId)
        {
            return await context.Schools.Where(s => s.PolicyId == policyId &&
                            !s.IsDeleted && s.IsActive).ToListAsync();
        }
        public async Task<Domain.Entities.School?> GetBySanitizedNameAsync(string sanitizeName)
        {
            return await context.Schools.FirstOrDefaultAsync(s =>s.sanitizeName == sanitizeName &&
            !s.IsDeleted);
        }
        public async Task<int> GetTotalCountActiveSchoolsAsync()
        {
            return await context.Schools.CountAsync(s =>!s.IsDeleted &&s.IsActive);
        }
        public async Task SetActiveStatusAsync(Guid schoolId, bool isActive)
        {
            var school = await context.Schools
           .FirstOrDefaultAsync(s => s.Id == schoolId && !s.IsDeleted);

            if (school == null)
                throw new KeyNotFoundException("School not found");

            school.IsActive = isActive;
            context.Schools.Update(school);
            await context.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(Guid schoolId)
        {
            var school = await context.Schools
                .FirstOrDefaultAsync(s => s.Id == schoolId);

            if (school == null)
                throw new KeyNotFoundException("School not found");

            school.IsDeleted = true;
            school.IsActive = false;

            context.Schools.Update(school);
            await context.SaveChangesAsync();
        }
        public Task<IEnumerable<SchoolDTO>> GetAllAsDtoAsync(int paging = 1, int pageSize = 10)
        {
            return context.Schools
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Name)
                .Skip((paging - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new SchoolDTO
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
                .ToListAsync()
                .ContinueWith(t => t.Result.AsEnumerable());
        }
    }
}
