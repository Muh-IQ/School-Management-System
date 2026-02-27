using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories;

internal class LanguageRepository(SchoolDbContext context) : ILanguageRepository
{
    public async Task<IEnumerable<LanguageDTO>> GetAllAsync()
    {
        return await context.Languages
            .Where(l => l.IsActive && !l.IsDeleted)
            .Select(l => new LanguageDTO
            {
                Id = l.Id,
                Name = l.Name
            })
            .ToListAsync();
    }

    public async Task<LanguageDTO?> GetByIdAsync(Guid id)
    {
        return await context.Languages
            .Where(l => l.Id == id && l.IsActive && !l.IsDeleted)
            .Select(l => new LanguageDTO
            {
                Id = l.Id,
                Name = l.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<LanguageDTO>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await context.Languages
            .Where(l => l.IsActive && !l.IsDeleted)
            .OrderBy(l => l.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(l => new LanguageDTO
            {
                Id = l.Id,
                Name = l.Name
            })
            .ToListAsync();
    }
}
