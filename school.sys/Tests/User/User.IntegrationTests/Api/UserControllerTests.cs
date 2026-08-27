using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Domain.Entities;
using Modules.IdP.Infrastructure.Presistent;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace User.IntegrationTests.Api;

public class UserControllerTests
{

    #region CreateUser
    [Fact]
    public async Task CreateUser_Should_Return202_With_SuccessResponse()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();
        await AddSchoolAdminRoleAsync(factory);
        var command = CreateValidUserCommand(
            email: "test.user@test.com",
            phone: "+9647712345678");

        var response = await client.PostAsJsonAsync("/api/v1/user", command);

        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        var body = await ReadJsonAsync(response);
        body.RootElement.GetProperty("success").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public async Task CreateUser_Should_Return202_When_DataIsValid()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();
        await AddSchoolAdminRoleAsync(factory);
        var command = CreateValidUserCommand(
            email: "valid.user@test.com",
            phone: "+9647812345678");

        var response = await client.PostAsJsonAsync("/api/v1/user", command);

        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        var body = await ReadJsonAsync(response);
        body.RootElement.GetProperty("success").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public async Task CreateUser_Should_Return400_When_ValidationFails()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();
        var command = new AddUserDTO
        {
            Name = string.Empty,
            Email = "invalid-email",
            Phone = string.Empty,
            SchoolID = Guid.Empty,
            DateOfBirth = DateTime.UtcNow.AddDays(1)
        };

        var response = await client.PostAsJsonAsync("/api/v1/user", command);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var body = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        body.Should().NotBeNull();
        body!.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CreateUser_Should_Return409_When_EmailAlreadyExists()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();
        const string email = "duplicate.user@test.com";
        await AddUserAsync(factory, email, "+9647912345678");
        var command = CreateValidUserCommand(email, "+9647012345678");

        var response = await client.PostAsJsonAsync("/api/v1/user", command);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var body = await ReadJsonAsync(response);
        body.RootElement.GetProperty("success").GetBoolean().Should().BeFalse();
        body.RootElement.GetProperty("message").GetString().Should().Be("Email already exists");
    }

    #endregion

    #region Helper
    private static AddUserDTO CreateValidUserCommand(string email, string phone) => new()
    {
        Name = "Test User",
        Email = email,
        Phone = phone,
        SchoolID = Guid.NewGuid(),
        DateOfBirth = DateTime.UtcNow.AddYears(-20),
        gender = true
    };

    private static async Task AddSchoolAdminRoleAsync(UserWebApplicationFactory factory)
    {
        using var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
        context.Roles.Add(new Role
        {
            Id = Guid.NewGuid(),
            Name = "School Administrator",
            Code = "SCHOOL_ADMIN",
            IsActive = true,
            IsDeleted = false,
            CreateAt = DateTime.UtcNow
        });
        await context.SaveChangesAsync();
    }

    private static async Task AddUserAsync(UserWebApplicationFactory factory, string email, string phone)
    {
        using var scope = factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
        context.Users.Add(new Modules.IdP.Domain.Entities.User
        {
            Id = Guid.NewGuid(),
            Name = "Existing User",
            Email = email,
            Phone = phone,
            Password = "hashed-password",
            DOB = DateTime.UtcNow.AddYears(-25),
            Gender = true,
            StartDate = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false,
            CreateAt = DateTime.UtcNow
        });
        await context.SaveChangesAsync();
    }

    private static async Task<JsonDocument> ReadJsonAsync(HttpResponseMessage response) =>
        JsonDocument.Parse(await response.Content.ReadAsStringAsync());

    #endregion
}
