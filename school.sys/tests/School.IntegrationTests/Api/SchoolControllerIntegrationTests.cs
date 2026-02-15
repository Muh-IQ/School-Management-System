using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Modules.School.Domain.DTOs;
using Xunit;

namespace School.IntegrationTests.Api;

public class SchoolControllerIntegrationTests : IClassFixture<SchoolWebApplicationFactory>
{
    private readonly SchoolWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public SchoolControllerIntegrationTests(SchoolWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateSchool_WithValidDto_Returns201Created()
    {
        await _factory.EnsureDbSeededAsync();
        var dto = new SchoolAddDTO
        {
            Name = "Integration Test School",
            Email = $"test-{Guid.NewGuid():N}@school.com",
            Phone = $"+1{Guid.NewGuid():N}"[..15],
            LanguageId = _factory.DefaultLanguageId,
            PolicyTitle = "Test Policy",
            PolicyDescription = "Description",
            PolicyType = "Test"
        };

        var response = await _client.PostAsJsonAsync("/api/v1/school", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task CreateSchool_WithDuplicateEmail_Returns409Conflict()
    {
        var email = $"dup-{Guid.NewGuid():N}@school.com";
        var dto = new SchoolAddDTO
        {
            Name = "First School",
            Email = email,
            Phone = "+1111111111",
            LanguageId = _factory.DefaultLanguageId,
            PolicyTitle = "P",
            PolicyDescription = "D",
            PolicyType = "T"
        };
        await _client.PostAsJsonAsync("/api/v1/school", dto);

        var second = new SchoolAddDTO
        {
            Name = "Second School",
            Email = email,
            Phone = "+2222222222",
            LanguageId = _factory.DefaultLanguageId,
            PolicyTitle = "P",
            PolicyDescription = "D",
            PolicyType = "T"
        };
        var response = await _client.PostAsJsonAsync("/api/v1/school", second);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task GetSchoolById_WhenNotFound_Returns404()
    {
        var response = await _client.GetAsync($"/api/v1/school/{Guid.NewGuid()}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ListSchools_Returns200()
    {
        await _factory.EnsureDbSeededAsync();
        var response = await _client.GetAsync("/api/v1/school");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
