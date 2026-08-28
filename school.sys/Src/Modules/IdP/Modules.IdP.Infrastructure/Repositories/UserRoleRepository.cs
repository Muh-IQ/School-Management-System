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
    internal class UserRoleRepository(UserDbContext context) : IUserRoleRepository
    {
        public async Task StageInsert(Domain.Entities.UserRole entity)
        {
            await context.UserRoles.AddAsync(entity);
        }
    }
}
