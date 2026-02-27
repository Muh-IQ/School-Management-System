using FluentAssertions;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities.Place;
using Modules.School.Infrastructure.Persistent;
using Modules.School.WebAPI.Contracts;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace School.IntegrationTests.Api.School_Module;



public class LocationControllerTests
    : IClassFixture<SchoolWebApplicationFactory>
{

    //////Country/////
    [Fact]
    public async Task Countries_GetAsync_Should_Return200_With_Data()
    {
        // Arrange
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider
                .GetRequiredService<SchoolDbContext>();

            context.Countries.Add(new Country
            {
                Id = Guid.NewGuid(),
                Name = "Iraq",
                IsActive = true
            });

            context.Countries.Add(new Country
            {
                Id = Guid.NewGuid(),
                Name = "Germany",
                IsActive = true
            });

            await context.SaveChangesAsync();
        }

        // Act
        var response = await client.GetAsync("/api/v1/country");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content
            .ReadFromJsonAsync<ApiResponse<IEnumerable<LocationDTO>>>();

        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
        body.Data.Should().NotBeNull();
        body.Data!.Count().Should().Be(2);
    }

    [Fact]
    public async Task GetAsync_Should_Return404_When_NoCountries()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/country");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();

        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");
    }

    //////city/////
    [Fact]
    public async Task Cities_GetAsync_Should_Return200_With_Data()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var countryId = Guid.NewGuid();

        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();

            context.Countries.Add(new Country
            {
                Id = countryId,
                Name = "Iraq",
                IsActive = true
            });

            context.Cities.Add(new City
            {
                Id = Guid.NewGuid(),
                Name = "Baghdad",
                CountryId = countryId,
                IsActive = true
            });

            context.Cities.Add(new City
            {
                Id = Guid.NewGuid(),
                Name = "Basra",
                CountryId = countryId,
                IsActive = true
            });

            await context.SaveChangesAsync();
        }

        var response = await client.GetAsync($"/api/v1/country/{countryId}/city");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<LocationDTO>>>();
        body.Should().NotBeNull();
        body!.Success.Should().BeTrue();
        body.Data.Should().NotBeNull();
        body.Data!.Count().Should().Be(2);
    }
    [Fact]
    public async Task GetAsync_Should_Return404_When_NoCities()
    {
        using var factory = new SchoolWebApplicationFactory();
        var client = factory.CreateClient();
        var countryId = Guid.NewGuid();

        var response = await client.GetAsync($"/api/v1/country/{countryId}/city");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var body = await response.Content.ReadFromJsonAsync<ApiResponse>();
        body!.Success.Should().BeFalse();
        body.Message.Should().Be("Operation Failed");

    }

}