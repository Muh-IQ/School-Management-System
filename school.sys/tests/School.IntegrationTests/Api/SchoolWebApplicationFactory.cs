using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Modules.School.Domain.Entities;
using Modules.School.Infrastructure.Persistent;

namespace School.IntegrationTests.Api;

/// <summary>
/// Web application factory for School module integration tests.
/// Uses in-memory SQLite so tests run without a real database.
/// </summary>
public class SchoolWebApplicationFactory : WebApplicationFactory<Program>
{
    private bool _dbSeeded;
    private Guid _defaultLanguageId;

    /// <summary>
    /// Default Language Id seeded for tests. Use after calling EnsureDbSeededAsync.
    /// </summary>
    public Guid DefaultLanguageId => _defaultLanguageId;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureAppConfiguration((_, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["UseInMemoryDatabase"] = "true"
            });
        });
    }

    /// <summary>
    /// Ensures the in-memory database has a default Language so CreateSchool can succeed.
    /// Call once per test class or in test initialization.
    /// </summary>
    public async Task EnsureDbSeededAsync()
    {
        if (_dbSeeded) return;
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
        var existing = await context.Set<Language>().FirstOrDefaultAsync();
        if (existing != null)
        {
            _defaultLanguageId = existing.Id;
            _dbSeeded = true;
            return;
        }
        _defaultLanguageId = Guid.NewGuid();
        var lang = new Language
        {
            Id = _defaultLanguageId,
            Name = "English",
            Code = "en",
            IsActive = true,
            IsDeleted = false
        };
        context.Set<Language>().Add(lang);
        await context.SaveChangesAsync();
        _dbSeeded = true;
    }
}
