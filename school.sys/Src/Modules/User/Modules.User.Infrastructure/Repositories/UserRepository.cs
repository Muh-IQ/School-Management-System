using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.IRepositories;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Modules.User.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        public async Task<Domain.Entities.User?> GetByIdAsync(Guid id)
        {
            return await context.Users
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<UserDto>> GetUsersAsync(int page, int pageSize)
        {
            var users = await context.Users
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .Select(u => new UserDto
                     {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone=u.Phone,
                gender = u.Gender ? "Female" : "Male"
                ,DOB=u.DOB,
                IsActive=u.IsActive
            })
            .ToListAsync();

            return users;
        }
      
        /// <summary>
        /// Stages the specified entity for insertion into the database.
        /// The entity is added to the current <see cref="DbContext"/> change tracker,
        /// but no changes are persisted until <c>SaveChangesAsync</c> is called,
        /// typically through the <c>IUnitOfWork</c>.
        /// </summary>
        /// <param name="entity">The entity to be staged for insertion.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task StageInsert(Domain.Entities.User entity)
        {
            await context.Users.AddAsync(entity);
        }

        public async Task<bool> UpdateUserAsync(Domain.Entities.User user)
        {
            context.Users.Update(user);
            return await context.SaveChangesAsync() > 0;
        }


    }
}
