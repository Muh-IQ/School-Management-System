using Modules.School.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    public class TimeService:ITimeService
    {
        public DateTime UtcNow() => DateTime.UtcNow;

        public DateTime ConvertFromUTC(DateTime utcTime, string timeZoneId)
        {

            var timeZone=TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);        
        }

        public DateTime ConvertToUTC(DateTime localtime, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            return TimeZoneInfo.ConvertTimeToUtc(localtime, timeZone);


        }



    }
}
