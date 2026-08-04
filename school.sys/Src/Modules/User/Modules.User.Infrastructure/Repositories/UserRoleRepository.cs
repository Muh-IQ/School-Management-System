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
    internal class UserRoleRepository(UserDbContext context) : IUserRoleRepository
    {
        public async Task StageInsert(Domain.Entities.UserRole entity)
        {
            await context.UserRoles.AddAsync(entity);
        }
    }
}
