using Modules.User.Domain.DTOs;
using Modules.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.IRepositories
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Retrieves a role by its code.
        /// </summary>
        /// <param name="code">
        /// The role code. Use the constants defined in <see cref="RoleCodes"/>
        /// (e.g. <see cref="RoleCodes.SuperAdmin"/>, <see cref="RoleCodes.Teacher"/>)
        /// instead of hard-coded string values.
        /// </param>
        /// <returns>
        /// The matching <see cref="RoleDTO"/> if found; otherwise <c>null</c>.
        /// </returns>
        Task<RoleDTO?> GetByCodeAsync(string Code);
    }
}
