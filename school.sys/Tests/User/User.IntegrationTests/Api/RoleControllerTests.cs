using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Modules.IdP.Domain.Entities;
using Modules.IdP.Infrastructure.Presistent;
using System.Net;
using System.Text.Json;
using Xunit;

namespace User.IntegrationTests.Api;

public class RoleControllerTests : IClassFixture<UserWebApplicationFactory>
{

    #region GetByCode
    [Fact]
    public async Task GetByCode_Should_Return200_With_Data_When_RoleExists()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();
        var roleId = Guid.NewGuid();

        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            context.Roles.Add(new Role
            {
                Id = roleId,
                Name = "Teacher",
                Code = "TEACHER",
                IsActive = true,
                IsDeleted = false,
                CreateAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
        }

        var response = await client.GetAsync("/api/v1/role/TEACHER");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await ReadJsonAsync(response);
        body.RootElement.GetProperty("success").GetBoolean().Should().BeTrue();
        var data = body.RootElement.GetProperty("data");
        data.GetProperty("id").GetGuid().Should().Be(roleId);
        data.GetProperty("name").GetString().Should().Be("Teacher");
    }

    [Fact]
    public async Task GetByCode_Should_Return404_When_RoleDoesNotExist()
    {
        using var factory = new UserWebApplicationFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/role/UNKNOWN");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var body = await ReadJsonAsync(response);
        body.RootElement.GetProperty("success").GetBoolean().Should().BeFalse();
        body.RootElement.GetProperty("message").GetString()
            .Should().Be("Role with code 'UNKNOWN' not found.");
    }
    #endregion

    #region Helper

    private static async Task<JsonDocument> ReadJsonAsync(HttpResponseMessage response) =>
        JsonDocument.Parse(await response.Content.ReadAsStringAsync());
    #endregion
}
