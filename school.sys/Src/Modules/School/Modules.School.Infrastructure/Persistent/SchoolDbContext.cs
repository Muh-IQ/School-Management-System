using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent
{
   
    public class SchoolDbContext :DbContext
    {

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {

        }
        public DbSet<Language> Languages {  get; set; }
        public DbSet<Domain.Entities.School> Schools { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.School>()
                .HasOne(s => s.Language)
                .WithMany()
                .HasForeignKey(s => s.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domain.Entities.School>()
                .HasOne(s => s.Policy)
                .WithMany()
                .HasForeignKey(s => s.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
