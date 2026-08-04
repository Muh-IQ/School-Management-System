using Modules.User.Application.Common.Results;
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
        public async Task<Result<RoleDTO?>> GetByCodeAsync(string Code)
        {
            var res = await repository.GetByCodeAsync(Code);
            return res is null ? Result<RoleDTO?>.
                Failure(ErrorType.NotFound, $"Role with code '{Code}' not found.") 
                : Result<RoleDTO?>.Success(res);
        }
    }
}
