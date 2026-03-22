using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.Entities;

namespace Modules.User.Infrastructure.Presistent
{
 
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Use module-specific schema
            modelBuilder.HasDefaultSchema("user");

            // ✅ Apply all IEntityTypeConfiguration<> in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}