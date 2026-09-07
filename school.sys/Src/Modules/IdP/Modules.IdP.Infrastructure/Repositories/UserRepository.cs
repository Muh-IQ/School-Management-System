using Microsoft.EntityFrameworkCore;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.Infrastructure.Presistent;


namespace Modules.IdP.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {


        public async Task<Domain.Entities.User?> GetByIdAsync(Guid id)
        {
            return await context.Users
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<UserTokenDTO?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return context.Users
                .Where(u => u.Email == email && u.Password == password)
                .Select(u => new UserTokenDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    RoleCode = u.UserRoles
                        .Where(ur => ur.IsActive && ur.Role.IsActive)
                        .Select(ur => ur.Role.Code)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();
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
                ,DOB=u.DateOfBirth,
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
