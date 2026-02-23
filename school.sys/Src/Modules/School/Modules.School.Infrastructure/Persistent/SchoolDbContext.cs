using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.Entities;
using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent
{

    /*
     * should be not removed by anyone> this for mohammed ajaj
     
    dotnet ef migrations add AddLocationEntities \ --project Src/Modules/School/Modules.School.Infrastructure \ --startup-project Src/Modules/School/Modules.School.WebAPI
    dotnet ef database update --project Src/Modules/School/Modules.School.Infrastructure --startup-project Src/Modules/School/Modules.School.WebAPI

     
     */

    public class SchoolDbContext :DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options){}
        public DbSet<Language> Languages { get; set; }
        public DbSet<Domain.Entities.School> Schools { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);
            
        }

    }
}
