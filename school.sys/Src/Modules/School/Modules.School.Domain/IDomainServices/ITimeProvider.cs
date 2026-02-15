using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.IThirdPartyServices
{
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current time in UTC.
        /// </summary>
        DateTime UtcNow { get; }

        /// <summary>
        /// Converts a UTC time to a specific time zone.
        /// </summary>
        DateTime ConvertToTimeZone(DateTime utcDateTime, string timeZoneId);

        /// <summary>
        /// Converts a local time from a specific time zone to UTC.
        /// </summary>
        DateTime ConvertToUtc(DateTime localDateTime, string timeZoneId);
    }
}
