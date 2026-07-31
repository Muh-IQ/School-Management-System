using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.IRepositories;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        public async Task<bool> AddAsync(Domain.Entities.User entity)
        {
            await context.Users.AddAsync(entity);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(Domain.Entities.User entity)
        {
            context.Users.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<Domain.Entities.User?> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
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

        public async Task<bool> UpdateAsync(Domain.Entities.User entity)
        {
            context.Users.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
