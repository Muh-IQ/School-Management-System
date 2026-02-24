using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Modules.School.Domain.DTOs;
using Modules.School.WebAPI.Contracts;
using System.Net;
using System.Net.Http.Json;
using Xunit;
namespace School.IntegrationTests.Api.School_Module;
public class SchoolControllerTests
    : IClassFixture<SchoolWebApplicationFactory>
{

    [Fact]
    public async Task CreateSchool_Should_Return201_With_SuccessResponse()
    {
        // Arrange
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var dto = new SchoolAddDTO
        {
            Name = "Test School",
            Email = "test@test.com",
            Phone = "123456",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "Policy",
            PolicyDescription = "Description",
            PolicyType = "General"
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/school", dto);

        // Assert status code
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var apiResponse = await response.Content
            .ReadFromJsonAsync<ApiResponse>();

        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Message.Should().Be("Operation Successed"); // based on your ApiResponse.Ok()
    }

    [Fact]
    public async Task CreateSchool_Should_Return201_When_DataIsValid()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var dto = new SchoolAddDTO
        {
            Name = "Test School",
            Email = "test@test.com",
            Phone = "123456",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "Policy",
            PolicyDescription = "Description",
            PolicyType = "General"
        };

        var response = await client.PostAsJsonAsync("/api/v1/school", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body!.Success.Should().BeTrue();
    }

    [Fact]
    public async Task CreateSchool_Should_Return400_When_ValidationFails()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var dto = new SchoolAddDTO
        {
            Name = "", // invalid
            Email = "invalid-email",
            Phone = "",
            LanguageId = Guid.Empty
        };

        var response = await client.PostAsJsonAsync("/api/v1/school", dto);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();

        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Validation Error");
        body.Errors.Should().NotBeNull();
        body.Errors!.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task CreateSchool_Should_Return409_When_Duplicate()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var dto = new SchoolAddDTO
        {
            Name = "Duplicate",
            Email = "dup@test.com",
            Phone = "123",
            LanguageId = Guid.NewGuid()
        };

        // First creation
        await client.PostAsJsonAsync("/api/v1/school", dto);

        // Second creation (should fail if domain prevents duplicates)
        var response = await client.PostAsJsonAsync("/api/v1/school", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");
    }
}
