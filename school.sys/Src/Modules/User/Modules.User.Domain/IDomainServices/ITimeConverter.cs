using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.IDomainServices
{
    public interface ITimeConverter
    {
        DateTime ConvertLocalToUtc(DateTime localDateTime, string timeZoneId);
        DateTime ConvertUtcToLocal(DateTime utcDateTime, string timeZoneId);
        
        }
    }
