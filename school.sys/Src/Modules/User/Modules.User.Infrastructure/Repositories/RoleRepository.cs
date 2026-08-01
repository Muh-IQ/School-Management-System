using Modules.User.Domain.DTOs;
using Modules.User.Domain.IRepositories;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly UserDbContext _context;

        public RoleRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<RoleDTO?> GetByCodeAsync(string code)
        {
            return await _context.Roles
                .Where(r => r.Code == code)
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
