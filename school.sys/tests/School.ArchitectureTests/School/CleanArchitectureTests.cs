using System.Linq;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace School.ArchitectureTests.School;

/// <summary>
/// Enforces Clean Architecture boundaries for the School module.
/// Think like a senior .NET architect working in a production enterprise system.
/// </summary>
public class CleanArchitectureTests
{
    private const string DomainNamespace = "Modules.School.Domain";
    private const string ApplicationNamespace = "Modules.School.Application";
    private const string InfrastructureNamespace = "Modules.School.Infrastructure";
    private const string WebApiNamespace = "Modules.School.WebAPI";

    [Fact]
    public void Domain_Should_NotReference_Infrastructure()
    {
        var result = Types.InAssembly(typeof(Modules.School.Domain.Entities.School).Assembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }

    [Fact]
    public void Domain_Should_NotReference_WebAPI()
    {
        var result = Types.InAssembly(typeof(Modules.School.Domain.Entities.School).Assembly)
            .Should()
            .NotHaveDependencyOn(WebApiNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }

    [Fact]
    public void Application_Should_NotReference_Infrastructure()
    {
        var result = Types.InAssembly(typeof(Modules.School.Application.Services.SchoolService).Assembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }

    [Fact]
    public void Application_Should_NotReference_WebAPI()
    {
        var result = Types.InAssembly(typeof(Modules.School.Application.Services.SchoolService).Assembly)
            .Should()
            .NotHaveDependencyOn(WebApiNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }

    [Fact]
    public void Infrastructure_Repositories_Should_Reference_Domain()
    {
        var result = Types.InAssembly(typeof(Modules.School.Infrastructure.Repositories.SchoolRepositories).Assembly)
            .That()
            .ResideInNamespace("Modules.School.Infrastructure.Repositories")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }

    [Fact]
    public void WebAPI_Controllers_Should_Reference_Application()
    {
        var result = Types.InAssembly(typeof(Modules.School.WebAPI.Controllers.V1.SchoolController).Assembly)
            .That()
            .ResideInNamespace("Modules.School.WebAPI.Controllers")
            .Should()
            .HaveDependencyOn(ApplicationNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(string.Join(", ", result.FailingTypes?.Select(t => t.FullName ?? t.Name) ?? Enumerable.Empty<string>()));
    }
}
