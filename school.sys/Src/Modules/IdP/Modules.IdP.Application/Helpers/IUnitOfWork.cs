using Modules.IdP.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.Helpers
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
