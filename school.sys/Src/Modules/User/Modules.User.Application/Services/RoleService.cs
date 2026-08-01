using Modules.User.Application.IServices;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Services
{
    internal class RoleService(IRoleRepository repository) : IRoleService
    {
        public async Task<RoleDTO?> GetByCodeAsync(string Code)
        {
            return await repository.GetByCodeAsync(Code);
        }
    }
}
