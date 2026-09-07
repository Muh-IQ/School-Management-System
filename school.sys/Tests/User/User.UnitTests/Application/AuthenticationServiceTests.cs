using FluentAssertions;
using Microsoft.Extensions.Options;
using Modules.IdP.Application.Common;
using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.IServices;
using Modules.IdP.Application.Services;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using Moq;
using SharedKernel;
using Xunit;

namespace User.UnitTests.Application;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ICacheService> _cacheServiceMock;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _cacheServiceMock = new Mock<ICacheService>();

        var jwtSettings = new JWTSttings
        {
            SecretKey = "ThisIsAVeryLongSecretKeyForTestingJWT123456789",
            Issuer = "TestIssuer",
            Audience = "TestAudience",
            ExpirationInMinutes = 60
        };

        var options = Options.Create(jwtSettings);

        _authenticationService = new AuthenticationService(
            _userRepositoryMock.Object,
            options,
            _cacheServiceMock.Object);
    }

    [Fact]
    public async Task LoginAsync_Should_ReturnUnauthorized_When_CredentialsAreInvalid()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "WrongPassword";

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(0);

        _userRepositoryMock
            .Setup(x => x.GetUserByEmailAndPasswordAsync(email, password))
            .ReturnsAsync((UserTokenDTO?)null);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.MainError.ErrorType.Should().Be(ErrorType.Unauthorized);
        result.MainError.Message.Should()
            .Be(UserErrors.InvalidCredentialsMessage());

        _cacheServiceMock.Verify(
            x => x.SetAsync(
                attemptKey,
                1,
                TimeSpan.FromMinutes(15)),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_Should_ReturnLocked_When_AttemptsAreAlreadyFive()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "WrongPassword";

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(5);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.MainError.ErrorType.Should().Be(ErrorType.Unauthorized);
        result.MainError.Message.Should()
            .Be(UserErrors.AccountLockedMessage());

        _userRepositoryMock.Verify(
            x => x.GetUserByEmailAndPasswordAsync(email, password),
            Times.Never);
    }

    [Fact]
    public async Task LoginAsync_Should_ReturnLocked_When_FifthAttemptFails()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "WrongPassword";

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(4);

        _userRepositoryMock
            .Setup(x => x.GetUserByEmailAndPasswordAsync(email, password))
            .ReturnsAsync((UserTokenDTO?)null);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.MainError.ErrorType.Should().Be(ErrorType.Unauthorized);
        result.MainError.Message.Should()
            .Be(UserErrors.AccountLockedMessage());

        _cacheServiceMock.Verify(
            x => x.SetAsync(
                attemptKey,
                5,
                TimeSpan.FromMinutes(15)),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_Should_IncrementAttempts_When_CredentialsAreInvalid()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "WrongPassword";

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(2);

        _userRepositoryMock
            .Setup(x => x.GetUserByEmailAndPasswordAsync(email, password))
            .ReturnsAsync((UserTokenDTO?)null);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeFalse();

        _cacheServiceMock.Verify(
            x => x.SetAsync(
                attemptKey,
                3,
                TimeSpan.FromMinutes(15)),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_Should_ReturnSuccess_When_CredentialsAreValid()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "CorrectPassword";

        var userId = Guid.NewGuid();

        var user = new UserTokenDTO
        {
            Id = userId,
            Email = email,
            RoleCode = "STUDENT"
        };

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";
        var tokenKey = $"USER-TOKEN-{userId}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(0);

        _userRepositoryMock
            .Setup(x => x.GetUserByEmailAndPasswordAsync(email, password))
            .ReturnsAsync(user);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNullOrEmpty();

        _cacheServiceMock.Verify(
            x => x.RemoveAsync(attemptKey),
            Times.Once);

        _cacheServiceMock.Verify(
            x => x.SetAsync(
                tokenKey,
                It.IsAny<string>(),
                TimeSpan.FromHours(1)),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_Should_RemoveFailedAttempts_When_LoginIsSuccessful()
    {
        // Arrange
        var email = "test@gmail.com";
        var password = "CorrectPassword";

        var user = new UserTokenDTO
        {
            Id = Guid.NewGuid(),
            Email = email,
            RoleCode = "STUDENT"
        };

        var attemptKey = $"LOGIN-ATTEMPTS-{email.ToLowerInvariant()}";

        _cacheServiceMock
            .Setup(x => x.GetAsync<int>(attemptKey))
            .ReturnsAsync(4);

        _userRepositoryMock
            .Setup(x => x.GetUserByEmailAndPasswordAsync(email, password))
            .ReturnsAsync(user);

        // Act
        var result = await _authenticationService.LoginAsync(email, password);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _cacheServiceMock.Verify(
            x => x.RemoveAsync(attemptKey),
            Times.Once);
    }
}

