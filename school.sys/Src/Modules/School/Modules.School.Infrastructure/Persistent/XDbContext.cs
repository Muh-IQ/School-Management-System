using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Infrastructure.Persistent
{
   
    public class XDbContext :DbContext
    {
      public  XDbContext(DbContextOptions<DbContext> options)   
            : base(options)
        {
         
        }

    }
}
