using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Modules.School.Infrastructure.Persistent;
using System;

public class SchoolWebApplicationFactory
    : WebApplicationFactory<Program>
{
    private readonly string _dbName = Guid.NewGuid().ToString(); // fixed per instance

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<SchoolDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<SchoolDbContext>(options =>
            {
                options.UseInMemoryDatabase(_dbName); // shared name
            });
        });
    }
}