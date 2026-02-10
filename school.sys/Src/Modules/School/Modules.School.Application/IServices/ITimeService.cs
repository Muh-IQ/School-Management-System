using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface ITimeService
    {
        DateTime UtcNow();
        DateTime ConvertFromUTC(DateTime utctime, string timeZoneId);
        DateTime ConvertToUTC(DateTime localtime, string timeZoneId);

    }
}
