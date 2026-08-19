using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.BatchRecord
{
    public sealed record UserRegistrationBatchItem(
     Domain.Entities.User User,
     Domain.Entities.UserRole UserRole);
}
