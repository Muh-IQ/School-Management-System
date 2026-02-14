using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.ThirdParty.Security
{
    public interface  IOtpGenerator
    {
         string Generate(int length = 6);

    }
}
