using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.Entities.Place;
using Modules.School.Infrastructure.Persistent;
using Modules.School.WebAPI.Contracts;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace School.IntegrationTests.Api;

public class SchoolControllerTests
{
    [Fact]
    public async Task CreateSchool_Should_Return201_With_SuccessResponse()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var command = await CreateValidSchoolCommandAsync(
            factory,
            name: "Test School",
            email: "test@test.com",
            phone: "+9647712345678");

        var response = await client.PostAsJsonAsync("/api/v1/school", command);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
        body.Message.Should().Be("Operation Successed");
    }

    [Fact]
    public async Task CreateSchool_Should_Return201_When_DataIsValid()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var command = await CreateValidSchoolCommandAsync(
            factory,
            name: "Valid School",
            email: "valid@test.com",
            phone: "+9647812345678");

        var response = await client.PostAsJsonAsync("/api/v1/school", command);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
    }

    [Fact]
    public async Task CreateSchool_Should_Return400_When_ValidationFails()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var command = new SchoolAddCommand
        {
            Name = string.Empty,
            Email = "invalid-email",
            Phone = "123",
            LanguageId = Guid.Empty
        };

        var response = await client.PostAsJsonAsync("/api/v1/school", command);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        // The currently configured API pipeline returns ASP.NET Core's standard
        // validation-problem payload for invalid request models.
        var body = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        body.Should().NotBeNull();
        body!.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CreateSchool_Should_Return409_When_Duplicate()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var command = await CreateValidSchoolCommandAsync(
            factory,
            name: "Duplicate School",
            email: "duplicate@test.com",
            phone: "+9647912345678");

        var firstResponse = await client.PostAsJsonAsync("/api/v1/school", command);
        firstResponse.StatusCode.Should().Be(HttpStatusCode.Created);

        var response = await client.PostAsJsonAsync("/api/v1/school", command);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body.Should().NotBeNull();
        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");
        body.Errors.Should().NotBeEmpty();
    }

    private static async Task<SchoolAddCommand> CreateValidSchoolCommandAsync(
        SchoolWebApplicationFactory factory,
        string name,
        string email,
        string phone)
    {
        var languageId = Guid.NewGuid();
        var countryId = Guid.NewGuid();
        var cityId = Guid.NewGuid();
        var areaId = Guid.NewGuid();

        using var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();

        context.Languages.Add(new Language
        {
            Id = languageId,
            Name = "English",
            Code = "en",
            IsActive = true,
            IsDeleted = false
        });
        context.Countries.Add(new Country
        {
            Id = countryId,
            Name = "Test Country",
            IsActive = true,
            IsDeleted = false
        });
        context.Cities.Add(new City
        {
            Id = cityId,
            Name = "Test City",
            CountryId = countryId,
            IsActive = true,
            IsDeleted = false
        });
        context.Areas.Add(new Area
        {
            Id = areaId,
            Name = "Test Area",
            CityId = cityId,
            IsActive = true,
            IsDeleted = false
        });
        await context.SaveChangesAsync();

        return new SchoolAddCommand
        {
            Name = name,
            Email = email,
            Phone = phone,
            LanguageId = languageId,
            CountryId = countryId,
            CityId = cityId,
            AreaId = areaId,
            PolicyTitle = "Policy",
            PolicyDescription = "Description"
        };
    }
}
