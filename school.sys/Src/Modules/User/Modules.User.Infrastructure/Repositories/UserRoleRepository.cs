using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.Entities;
using Modules.User.Domain.IRepositories;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserDbContext _context;

        public UserRoleRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AssignRoleToUserAsync(Guid userId, Guid roleId)
        {
      
            if (await ExistsAsync(userId,roleId))
                return;

            await _context.UserRoles.AddAsync(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
        }

        public async Task RemoveRoleFromUserAsync(Guid userId, Guid roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
                
            if (userRole is null)
                return;

            _context.UserRoles.Remove(userRole);
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid roleId)
        {
            return await _context.UserRoles
                .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);
        }
    }
}
