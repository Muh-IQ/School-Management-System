using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.Services
{
    public class RoleService(IRoleRepository repository, ICacheService cacheService) : IRoleService
    {
        public async Task<Result<RoleDTO?>> GetByCodeAsync(string Code)
        {
            var res = await  cacheService.GetOrCreateAsync(
                key:$"ROLE--CODE--{Code}", 
                async () => await repository.GetByCodeAsync(Code),
                TimeSpan.FromDays(365));


            return res is null ? Result<RoleDTO?>.
                Failure(ErrorType.NotFound, $"Role with code '{Code}' not found.") 
                : Result<RoleDTO?>.Success(res);
        }
    }
}
