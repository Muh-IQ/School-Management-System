using Modules.User.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<DTOs.UserDto>> GetUsersAsync(int page, int pageSize);

        /// <summary>
        /// Stages the specified entity for insertion into the database.
        /// The entity is added to the current <see cref="DbContext"/> change tracker,
        /// but no changes are persisted until <c>SaveChangesAsync</c> is called,
        /// typically through the <c>IUnitOfWork</c>.
        /// </summary>
        /// <param name="entity">The entity to be staged for insertion.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task StageInsert(Domain.Entities.User entity);

        Task<bool> UpdateUserActiveStatusAsync(Guid userId, bool isActive);

        Task<int> UpdateUsersActiveStatusAsync(IEnumerable<Guid> userIds, bool isActive);

    }


}
