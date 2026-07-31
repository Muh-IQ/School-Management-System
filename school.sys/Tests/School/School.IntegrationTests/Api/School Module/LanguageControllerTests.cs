using FluentAssertions;
using Modules.School.Domain.Entities;
using Modules.School.Domain.DTOs;
using Modules.School.Infrastructure.Persistent;
using Modules.School.WebAPI.Contracts;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace School.IntegrationTests.Api.School_Module;

public class LanguageControllerTests : IClassFixture<SchoolWebApplicationFactory>
{
    [Fact]
    public async Task GetAll_Should_Return200_With_Data_When_Languages_Exist()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
            context.Languages.Add(new Language
            {
                Id = Guid.NewGuid(),
                Name = "English",
                Code = "en",
                IsActive = true,
                IsDeleted = false
            });
            context.Languages.Add(new Language
            {
                Id = Guid.NewGuid(),
                Name = "Arabic",
                Code = "ar",
                IsActive = true,
                IsDeleted = false
            });
            await context.SaveChangesAsync();
        }

        var response = await client.GetAsync("/api/v1/language");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<LanguageDTO>>>();
        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
        body.Data.Should().NotBeNull();
        body.Data!.Count().Should().Be(2);
        body.Data!.Select(l => l.Name).Should().Contain(new[] { "English", "Arabic" });

        var cacheControl = response.Headers.GetValues("Cache-Control").FirstOrDefault();
        cacheControl.Should().NotBeNullOrEmpty();
        cacheControl!.Should().Contain("max-age=31536000");
        cacheControl.Should().Contain("immutable");
    }

    [Fact]
    public async Task GetAll_Should_Return404_When_No_Languages()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/language");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body.Should().NotBeNull();
        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");
    }

    [Fact]
    public async Task GetById_Should_Return200_With_Data_When_Language_Exists()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var languageId = Guid.NewGuid();

        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
            context.Languages.Add(new Language
            {
                Id = languageId,
                Name = "French",
                Code = "fr",
                IsActive = true,
                IsDeleted = false
            });
            await context.SaveChangesAsync();
        }

        var response = await client.GetAsync($"/api/v1/language/{languageId}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse<LanguageDTO>>();
        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
        body.Data.Should().NotBeNull();
        body.Data!.Id.Should().Be(languageId);
        body.Data!.Name.Should().Be("French");
    }

    [Fact]
    public async Task GetById_Should_Return404_When_Language_Not_Found()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var nonExistentId = Guid.NewGuid();

        var response = await client.GetAsync($"/api/v1/language/{nonExistentId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body.Should().NotBeNull();
        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");
    }
}
