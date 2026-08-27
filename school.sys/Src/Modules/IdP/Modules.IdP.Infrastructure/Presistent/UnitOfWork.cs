using Modules.IdP.Application.Helpers;
using Modules.IdP.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure.Presistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _context;

        public IUserRepository Users { get; }

        public IUserRoleRepository UserRoles { get; }

        public UnitOfWork(
            UserDbContext context,
            IUserRepository users,
            IUserRoleRepository userRoles)
        {
            _context = context;
            Users = users;
            UserRoles = userRoles;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
