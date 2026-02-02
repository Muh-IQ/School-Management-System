using Microsoft.EntityFrameworkCore;
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
    public class SchoolRepositories(SchoolDbContext context) : ISchoolRepository
    {
        public async Task<bool> CanDeleteAsync(Guid schoolId)
        {
            return await context.Schools.AnyAsync(
                s => s.Id == schoolId && !s.IsDeleted &&
                s.LanguageId != Guid.Empty && s.PolicyId != Guid.Empty);
        }

        public async Task<bool> CanUpdateAsync(Guid schoolId, string newName)
        {
            return !await context.Schools.AnyAsync(s=>s.Id!=schoolId && !s.IsDeleted &&
            s.Name == newName);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await context.Schools.AnyAsync(s => s.Name == name && !s.IsDeleted);
        }

        public async Task<IEnumerable<Schools>> GetActiveSchoolsAsync()
        {
            return await context.Schools.Where(s=>s.IsActive && !s.IsDeleted).ToListAsync();
        }

        public async Task<Schools?> GetByIdWithDetailsAsync(Guid schoolId)
        {
            return await context.Schools.Include(s => s.Language).Include(s => s.Policy).
                FirstOrDefaultAsync(s => s.Id == schoolId && !s.IsDeleted);
        }

        public async Task<IEnumerable<Schools>> GetByLanguageAsync(Guid languageId)
        {
            return await context.Schools.Where(s=>s.LanguageId==languageId&&
                !s.IsDeleted && s.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Schools>> GetByPolicyAsync(Guid policyId)
        {
            return await context.Schools.Where(s => s.PolicyId == policyId &&
                            !s.IsDeleted && s.IsActive).ToListAsync();
        }

        public async Task<Schools?> GetBySanitizedNameAsync(string sanitizeName)
        {
            return await context.Schools.FirstOrDefaultAsync(s =>s.sanitizeName == sanitizeName &&
            !s.IsDeleted);
        }

        public async Task<IEnumerable<Schools>> GetSchoolsAsync(int page, int pageSize, string? searchTerm)
        {
            IQueryable<Schools> query=context.Schools.Where(s=>!s.IsDeleted);
            if(!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(s => s.Name.Contains(searchTerm));
            }
            return await query.OrderBy(s => s.Name).Skip((page - 1) * pageSize)
                    .Take(pageSize).ToListAsync();
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
    }
}
