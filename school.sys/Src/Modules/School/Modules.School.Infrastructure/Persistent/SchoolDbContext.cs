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
        public DbSet<Languages> Languages {  get; set; }
        public DbSet<Schools> Schools { get; set; }
        public DbSet<Policies> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schools>()
                .HasOne(s => s.Language)
                .WithMany()
                .HasForeignKey(s => s.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schools>()
                .HasOne(s => s.Policy)
                .WithMany()
                .HasForeignKey(s => s.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schools>()
                .OwnsOne(s => s.ContactInfo);
        }

    }
}
