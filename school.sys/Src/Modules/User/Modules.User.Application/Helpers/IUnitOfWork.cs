using Modules.User.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Helpers
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
