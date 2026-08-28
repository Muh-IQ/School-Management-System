using Modules.IdP.Application.Common.Results;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using Moq;
using Modules.IdP.Application.IServices;
using Modules.IdP.Application.Services;
namespace User.UnitTests.Application;



public class RoleServiceTests
{
    private readonly Mock<IRoleRepository> _repository;
    private readonly Mock<ICacheService> _cacheService;
    private readonly RoleService _service;

    public RoleServiceTests()
    {
        _repository = new Mock<IRoleRepository>();
        _cacheService = new Mock<ICacheService>();

        _service = new RoleService(_repository.Object, _cacheService.Object);
    }

    [Fact]
    public async Task GetByCodeAsync_ShouldReturnSuccess_WhenRoleExists()
    {
        // Arrange
        var code = "ADMIN";

        var role = new RoleDTO
        {
            Id = Guid.NewGuid(),
            Name = "Administrator"
        };

        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                $"ROLE--CODE--{code}",
                It.IsAny<Func<Task<RoleDTO?>>>(),
                TimeSpan.FromDays(365)))
            .ReturnsAsync(role);

        // Act
        var result = await _service.GetByCodeAsync(code);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(role.Id, result.Value!.Id);
        Assert.Equal(role.Name, result.Value.Name);
    }

    [Fact]
    public async Task GetByCodeAsync_ShouldReturnFailure_WhenRoleDoesNotExist()
    {
        // Arrange
        var code = "UNKNOWN";

        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                $"ROLE--CODE--{code}",
                It.IsAny<Func<Task<RoleDTO?>>>(),
                TimeSpan.FromDays(365)))
            .ReturnsAsync((RoleDTO?)null);

        // Act
        var result = await _service.GetByCodeAsync(code);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.MainError.ErrorType);
        Assert.Equal($"Role with code '{code}' not found.", result.MainError.Message);
    }
}
