using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Infrastructure.Persistent
{
   
    public class SchoolDbContext :DbContext
    {
        public  SchoolDbContext(DbContextOptions<DbContext> options)   
            : base(options)
        {
         
        }
        public DbSet<Languages> Languages {  get; set; }
        public DbSet<Schools> Schools { get; set; }
        public DbSet<Policies> Policies { get; set; }



    }
}
