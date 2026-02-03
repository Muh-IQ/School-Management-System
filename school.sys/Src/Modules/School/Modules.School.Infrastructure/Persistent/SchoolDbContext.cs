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
        public DbSet<Language> Languages {  get; set; }
        public DbSet<SChool> Schools { get; set; }
        public DbSet<Policy> Policies { get; set; }



    }
}
