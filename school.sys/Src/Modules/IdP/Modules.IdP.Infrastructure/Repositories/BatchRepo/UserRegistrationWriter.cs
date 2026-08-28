using Modules.IdP.Domain.BatchRecord;
using Modules.IdP.Infrastructure.Presistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure.Repositories.BatchRepo
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
