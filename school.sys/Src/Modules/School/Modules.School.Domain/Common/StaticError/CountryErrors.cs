using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Common.StaticError
{
    public class CountryErrors
    {
        public static string NotFoundMessage(Guid? id = null)
        {
            return id == null
                ? $"Country was not found."
                : $"Country with ID '{id}' was not found.";
        }
    }
}
