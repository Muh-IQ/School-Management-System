using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;

namespace Modules.School.Infrastructure.Repositories
{
    internal class PolicyRepository :GenericRepository<Policy>,IPolicyRepository
    {
        public PolicyRepository(SchoolDbContext _context) : base(_context)
        {
        }
        public async Task<Guid> GetDefaultPolicyIdAsync()
        {
            return await _context.Policies
                .Where(p => p.IsDefault)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
        }
    }
}
