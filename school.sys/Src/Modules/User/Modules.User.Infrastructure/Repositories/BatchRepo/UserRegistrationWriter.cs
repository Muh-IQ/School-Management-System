using Modules.User.Domain.BatchRecord;
using Modules.User.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Repositories.BatchRepo
{
    public sealed class UserRegistrationWriter(
    UserDbContext context) : IUserRegistrationWriter
    {
        public async Task WriteAsync(
            IReadOnlyCollection<UserRegistrationBatchItem> registrations)
        {
            foreach (var registration in registrations)
            {
                context.Users.Add(registration.User);
                context.UserRoles.Add(registration.UserRole);
            }

            await context.SaveChangesAsync();
        }
    }
}
