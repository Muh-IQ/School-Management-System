using Microsoft.EntityFrameworkCore;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.Entities;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure.Repositories
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
                .Where(r => r.Code == code && r.IsActive)
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RoleDTO?> GetByNameAsync(string name)
        {
                return await _context.Roles
                .Where(r => r.Name == name && r.IsActive)
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefaultAsync();
        }
        public async Task<Role?> GetWithUsersAsync(Guid roleId)
        {
            return await _context.Roles
                .Include(r => r.UserRoles)
                .ThenInclude(ur => ur.User)
                .FirstOrDefaultAsync(r => r.Id == roleId && r.IsActive);
        }
        public async Task<bool> HasUsersAsync(Guid roleId)
        {
            return await _context.UserRoles
                .AnyAsync(x => x.RoleId == roleId && x.IsActive);
        }
        public async Task<IEnumerable<RoleDTO>> GetRolesByUserIdAsync(Guid userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId && ur.Role.IsActive)
                .Select(ur => new RoleDTO
                {
                    Id = ur.Role.Id,
                    Name = ur.Role.Name
                    
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
