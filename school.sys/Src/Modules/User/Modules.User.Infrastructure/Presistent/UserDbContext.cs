using Microsoft.EntityFrameworkCore;
using Modules.User.Domain.Entities;
using Modules.User.Infrastructure.Presistent.Seeds;

namespace Modules.User.Infrastructure.Presistent
{
 
    public class UserDbContext : DbContext
    {
        private readonly IEnumerable<ISeeder> _seeders;
        public UserDbContext(DbContextOptions<UserDbContext> options, IEnumerable<ISeeder>? seeders = null)
            : base(options)
        {
            _seeders = seeders ?? Enumerable.Empty<ISeeder>();
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
            ApplySeeders(modelBuilder);
        }
        private void ApplySeeders(ModelBuilder modelBuilder)
        {
            foreach (var seeder in _seeders)
            {
                seeder.Seed(modelBuilder);
            }
        }
    }
}