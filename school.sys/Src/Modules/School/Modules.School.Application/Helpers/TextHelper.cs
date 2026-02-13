using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modules.School.Application.Helpers
{
    public static class TextHelper
    {
        public static string SlugGenerate(string Text)
        {
            if (string.IsNullOrWhiteSpace(Text))
                return string.Empty;
            string str = Text.ToLowerInvariant();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"-+", "-");
            str = str.Trim('-');
            return str;
        }
    }
}
