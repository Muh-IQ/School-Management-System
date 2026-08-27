using FluentAssertions;
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.Common.StaticError;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Application.Services;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.Entities;
using Modules.User.Domain.IRepositories;
using Modules.User.Domain.Utilities;
using Moq;
using SharedKernel;
using SharedKernel.Events;
using System.Linq.Expressions;
using Xunit;

using user = Modules.User.Domain.Entities;

namespace User.UnitTests.Application;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IUserRoleRepository> _userRoleRepository;
    private readonly Mock<IRoleService> _roleService;
    private readonly Mock<IGenericRepository<user.User>> _genericRepository;
    private readonly Mock<ICacheService> _cacheService;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IEventBus> _eventBus;
    private readonly UserService _service;
    private readonly MicroBatch<Modules.User.Domain.BatchRecord.UserRegistrationBatchItem> _userBatcher;
    //private readonly MicroBatch<Modules.User.Domain.Entities.UserRole> _userRoleBatcher;

    public UserServiceTests()
    {
        _userRepository = new Mock<IUserRepository>();
        _userRoleRepository = new Mock<IUserRoleRepository>();
        _roleService = new Mock<IRoleService>();
        _unitOfWork = new Mock<IUnitOfWork>();
        _genericRepository = new Mock<IGenericRepository<user.User>>();
        _cacheService = new Mock<ICacheService>();
        _eventBus = new Mock<IEventBus>();

        // Create MicroBatch instances
        _userBatcher = new MicroBatch<Modules.User.Domain.BatchRecord.UserRegistrationBatchItem>(
            100,
            TimeSpan.FromSeconds(10),
            async users => { });

        //_userRoleBatcher = new MicroBatch<Modules.User.Domain.Entities.UserRole>(
        //    100,
        //    TimeSpan.FromSeconds(10),
        //    async userRoles => { });

        _unitOfWork
            .Setup(x => x.Users)
            .Returns(_userRepository.Object);

        _unitOfWork
            .Setup(x => x.UserRoles)
            .Returns(_userRoleRepository.Object);

        _service = new UserService(
            _eventBus.Object,
            _roleService.Object,
            _userBatcher,
            //_userRoleBatcher,
            _genericRepository.Object,
            _cacheService.Object);
    }

    #region ValidateEmailUniquenessAsync

    [Fact]
    public async Task ValidateEmailUniquenessAsync_Should_ReturnFailure_When_EmailAlreadyExists()
    {
        // Arrange
        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(true);

        // Act
        var result = await _service.ValidateEmailUniquenessAsync(
            "test@test.com");

        // Assert
        Assert.True(result.IsFailure);

        Assert.Equal(
            ErrorType.Conflict,
            result.MainError.ErrorType);

        Assert.Equal(
            "Email already exists",
            result.MainError.Message);
    }

    [Fact]
    public async Task ValidateEmailUniquenessAsync_Should_ReturnSuccess_When_EmailDoesNotExist()
    {
        // Arrange
        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(false);

        // Act
        var result = await _service.ValidateEmailUniquenessAsync(
            "test@test.com");

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion


    #region ValidatePhoneUniquenessAsync

    [Fact]
    public async Task ValidatePhoneUniquenessAsync_Should_ReturnFailure_When_PhoneAlreadyExists()
    {
        // Arrange
        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(true);

        // Act
        var result = await _service.ValidatePhoneUniquenessAsync(
            "123456");

        // Assert
        Assert.True(result.IsFailure);

        Assert.Equal(
            ErrorType.Conflict,
            result.MainError.ErrorType);

        Assert.Equal(
            "Phone already exists",
            result.MainError.Message);
    }

    [Fact]
    public async Task ValidatePhoneUniquenessAsync_Should_ReturnSuccess_When_PhoneDoesNotExist()
    {
        // Arrange
        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(false);

        // Act
        var result = await _service.ValidatePhoneUniquenessAsync(
            "123456");

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion

    #region OpenSessionAsync

    [Fact]
    public async Task OpenSessionAsync_Should_CreateAndCacheSession_AndReturnKey()
    {
        // Arrange
        string? cachedKey = null;
        ResetEmailSession? cachedSession = null;
        TimeSpan? cachedExpiration = null;

        _cacheService
            .Setup(x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<ResetEmailSession>(),
                It.IsAny<TimeSpan?>()))
            .Callback<string, ResetEmailSession, TimeSpan?>(
                (key, session, expiration) =>
                {
                    cachedKey = key;
                    cachedSession = session;
                    cachedExpiration = expiration;
                })
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.OpenSessionAsync();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();

        cachedKey.Should().NotBeNullOrWhiteSpace();
        cachedKey.Should().Be(result.Value!.Key);

        cachedSession.Should().NotBeNull();
        cachedSession!.IsConfirmOldEmail.Should().BeFalse();
        cachedSession.IsConfirmNewEmail.Should().BeFalse();
        cachedSession.IsNewEmailExist.Should().BeTrue();
        cachedSession.NewEmail.Should().BeNull();

        cachedExpiration.Should().Be(TimeSpan.FromMinutes(15));

        _cacheService.Verify(
            x => x.SetAsync(
                It.Is<string>(key => key == result.Value.Key),
                It.Is<ResetEmailSession>(session =>
                    session.IsConfirmOldEmail == false &&
                    session.IsConfirmNewEmail == false &&
                    session.IsNewEmailExist == true &&
                    session.NewEmail == null),
                It.Is<TimeSpan?>(expiration =>
                    expiration == TimeSpan.FromMinutes(15))),
            Times.Once);
    }

    #endregion

    #region SendVerficationCodeUserAsync

    [Fact]
    public async Task SendVerficationCodeUserAsync_Should_ReturnSuccess_And_SendOtpToOldEmail_WhenSessionExists()
    {
        // Arrange
        const string sessionKey = "RESET-SESSION-123";

        var session = new ResetEmailSession
        {
            IsConfirmOldEmail = false,
            IsConfirmNewEmail = false,
            IsNewEmailExist = false,
            NewEmail = null
        };

        string? cachedOtp = null;
        UserVerifyIntegrationEvent? publishedEvent = null;

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _cacheService
            .Setup(x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>()))
            .Callback<string, string, TimeSpan?>(
                (_, otp, _) => cachedOtp = otp)
            .Returns(Task.CompletedTask);

        _eventBus
            .Setup(x => x.PublishAsync(
                It.IsAny<UserVerifyIntegrationEvent>(),
                It.IsAny<CancellationToken>()))
            .Callback<UserVerifyIntegrationEvent, CancellationToken>(
                (eventData, _) => publishedEvent = eventData)
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.SendVerficationCodeUserAsync(sessionKey);

        // Assert
        result.IsSuccess.Should().BeTrue();

        // OTP should be generated
        cachedOtp.Should().NotBeNullOrWhiteSpace();
        cachedOtp.Should().MatchRegex(@"^\d{6}$");

        // Event should be published
        publishedEvent.Should().NotBeNull();

        // We don't care about the temporary/mock email value
        publishedEvent!.email.Should().NotBeNullOrWhiteSpace();

        // The OTP sent by event must be the same OTP stored in cache
        publishedEvent.otp.Should().Be(cachedOtp);

        // Verify cache was accessed
        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(sessionKey),
            Times.Once);

        // Verify OTP was stored
        _cacheService.Verify(
            x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>()),
            Times.Once);

        // Verify event was published
        _eventBus.Verify(
            x => x.PublishAsync(
                It.IsAny<UserVerifyIntegrationEvent>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task SendVerficationCodeUserAsync_Should_ReturnBadRequest_WhenSessionKeyIsInvalid(
    string? sessionKey)
    {
        // Act
        var result = await _service.SendVerficationCodeUserAsync(sessionKey!);

        // Assert
        result.IsSuccess.Should().BeFalse();

        result.MainError.Should().NotBeNull();
        result.MainError.ErrorType.Should().Be(ErrorType.BadRequest);

        result.MainError.Message
            .Should()
            .Be(SessionErrors.InvalidSessionKeyMessage());

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(It.IsAny<string>()),
            Times.Never);

        _eventBus.Verify(
            x => x.PublishAsync(
                It.IsAny<UserVerifyIntegrationEvent>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task SendVerficationCodeUserAsync_Should_ReturnNotFound_WhenSessionDoesNotExist()
    {
        // Arrange
        const string sessionKey = "RESET-SESSION-123";

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync((ResetEmailSession?)null);

        // Act
        var result = await _service.SendVerficationCodeUserAsync(sessionKey);

        // Assert
        result.IsSuccess.Should().BeFalse();

        result.MainError.Should().NotBeNull();
        result.MainError.ErrorType.Should().Be(ErrorType.NotFound);

        result.MainError.Message
            .Should()
            .Be(SessionErrors.NotFoundMessage(sessionKey));

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(sessionKey),
            Times.Once);

        _eventBus.Verify(
            x => x.PublishAsync(
                It.IsAny<UserVerifyIntegrationEvent>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }
    #endregion

    #region VerifyUserAsync

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnSuccess_When_OtpIsCorrect()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmOldEmail = false,
            IsConfirmNewEmail = false,
            IsNewEmailExist = true
        };

        var otp = "834271";

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _cacheService
            .Setup(x => x.GetAsync<string>($"OTP:{sessionKey}"))
            .ReturnsAsync(otp);

        // Act

        var result = await _service.VerifyUserAsync(otp,sessionKey );

        // Assert

        Assert.True(result.IsSuccess);
        Assert.True(session.IsConfirmOldEmail);

        _cacheService.Verify(
            x => x.SetAsync(
                sessionKey,
                session,
                It.IsAny<TimeSpan>()),
            Times.Once);
    }

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnBadRequest_When_SessionKeyIsEmpty()
    {
        // Arrange

        var sessionKey = "";
        var otp = "834271";

        // Act

        var result = await _service.VerifyUserAsync(otp, sessionKey);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(It.IsAny<string>()),
            Times.Never);
    }

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnNotFound_When_SessionDoesNotExist()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var otp = "834271";

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync((ResetEmailSession?)null);

        // Act

        var result = await _service.VerifyUserAsync(otp, sessionKey);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.MainError.ErrorType);

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(sessionKey),
            Times.Once);

        _cacheService.Verify(
            x => x.GetAsync<string>($"OTP:{sessionKey}"),
            Times.Never);
    }

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnBadRequest_When_OtpIsEmpty()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var otp = "";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmNewEmail = false,
            IsConfirmOldEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        // Act

        var result = await _service.VerifyUserAsync(otp, sessionKey);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(sessionKey),
            Times.Once);

        _cacheService.Verify(
            x => x.GetAsync<string>($"OTP:{sessionKey}"),
            Times.Never);
    }

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnNotFound_When_OtpDoesNotExist()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var otp = "834271";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmNewEmail = false,
            IsConfirmOldEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _cacheService
            .Setup(x => x.GetAsync<string>($"OTP:{sessionKey}"))
            .ReturnsAsync((string?)null);

        // Act

        var result = await _service.VerifyUserAsync(otp, sessionKey);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.MainError.ErrorType);

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(sessionKey),
            Times.Once);

        _cacheService.Verify(
            x => x.GetAsync<string>($"OTP:{sessionKey}"),
            Times.Once);

        _cacheService.Verify(
            x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<ResetEmailSession>(),
                It.IsAny<TimeSpan>()),
            Times.Never);
    }

    [Fact]
    public async Task VerifyUserAsync_Should_ReturnBadRequest_When_OtpIsIncorrect()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";

        var enteredOtp = "123456";
        var storedOtp = "834271";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmNewEmail = false,
            IsConfirmOldEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _cacheService
            .Setup(x => x.GetAsync<string>($"OTP:{sessionKey}"))
            .ReturnsAsync(storedOtp);

        // Act

        var result = await _service.VerifyUserAsync(
            enteredOtp,
            sessionKey);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        Assert.False(session.IsConfirmOldEmail);

        _cacheService.Verify(
            x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<ResetEmailSession>(),
                It.IsAny<TimeSpan>()),
            Times.Never);

        _cacheService.Verify(
            x => x.RemoveAsync($"OTP:{sessionKey}"),
            Times.Never);
    }

    #endregion

    #region WriteNewEmailAsync

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnBadRequest_When_SessionKeyIsEmpty()
    {
        // Arrange

        var sessionKey = "";
        var newEmail = "new@email.com";

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        _cacheService.Verify(
            x => x.GetAsync<ResetEmailSession>(It.IsAny<string>()),
            Times.Never);

        _genericRepository.Verify(
            x => x.ExistsAsync(It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()),
            Times.Never);
    }

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnNotFound_When_SessionDoesNotExist()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var newEmail = "new@email.com";

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync((ResetEmailSession?)null);

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.MainError.ErrorType);

        _genericRepository.Verify(
            x => x.ExistsAsync(It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()),
            Times.Never);
    }

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnBadRequest_When_OldEmailIsNotConfirmed()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var newEmail = "new@email.com";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmOldEmail = false,
            IsConfirmNewEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        _genericRepository.Verify(
            x => x.ExistsAsync(It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()),
            Times.Never);

        _cacheService.Verify(
            x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<ResetEmailSession>(),
                It.IsAny<TimeSpan>()),
            Times.Never);
    }

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnBadRequest_When_NewEmailIsEmpty()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var newEmail = "";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmOldEmail = true,
            IsConfirmNewEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.BadRequest, result.MainError.ErrorType);

        _genericRepository.Verify(
            x => x.ExistsAsync(It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()),
            Times.Never);

        _cacheService.Verify(
            x => x.SetAsync(
                It.IsAny<string>(),
                It.IsAny<ResetEmailSession>(),
                It.IsAny<TimeSpan>()),
            Times.Never);
    }

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnConflict_When_NewEmailAlreadyExists()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var newEmail = "existing@email.com";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmOldEmail = true,
            IsConfirmNewEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _genericRepository
            .Setup(x => x.ExistsAsync(
                It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()))
            .ReturnsAsync(true);

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Conflict, result.MainError.ErrorType);

        Assert.True(session.IsNewEmailExist);
        Assert.Null(session.NewEmail);

        _cacheService.Verify(
            x => x.SetAsync(
                sessionKey,
                session,
                It.IsAny<TimeSpan>()),
            Times.Once);
    }

    [Fact]
    public async Task WriteNewEmailAsync_Should_ReturnSuccess_When_NewEmailDoesNotExist()
    {
        // Arrange

        var sessionKey = "RESET-EMAILSESSION-test";
        var newEmail = "new@email.com";

        var session = new ResetEmailSession
        {
            NewEmail = null,
            IsConfirmOldEmail = true,
            IsConfirmNewEmail = false,
            IsNewEmailExist = true
        };

        _cacheService
            .Setup(x => x.GetAsync<ResetEmailSession>(sessionKey))
            .ReturnsAsync(session);

        _genericRepository
            .Setup(x => x.ExistsAsync(
                It.IsAny<Expression<Func<Modules.User.Domain.Entities.User, bool>>>()))
            .ReturnsAsync(false);

        // Act

        var result = await _service.WriteNewEmailAsync(
            sessionKey,
            newEmail);

        // Assert

        Assert.True(result.IsSuccess);

        Assert.Equal(newEmail, session.NewEmail);
        Assert.False(session.IsNewEmailExist);

        _cacheService.Verify(
            x => x.SetAsync(
                sessionKey,
                session,
                It.IsAny<TimeSpan>()),
            Times.Once);
    }
    #endregion


    #region AddAsync

    [Fact]
    public async Task AddAsync_Should_ReturnFailure_When_EmailAlreadyExists()
    {
        // Arrange
        _cacheService
            .SetupSequence(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(true)   // Email exists
            .ReturnsAsync(false); // Phone doesn't exist

        // Act
        var result = await _service.AddAsync(CreateDto());

        // Assert
        Assert.True(result.IsFailure);

        _unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }


    [Fact]
    public async Task AddAsync_Should_ReturnFailure_When_PhoneAlreadyExists()
    {
        // Arrange
        _cacheService
            .SetupSequence(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(false) // Email doesn't exist
            .ReturnsAsync(true); // Phone exists

        // Act
        var result = await _service.AddAsync(CreateDto());

        // Assert
        Assert.True(result.IsFailure);

        _unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }


    [Fact]
    public async Task AddAsync_Should_ReturnFailure_When_EmailAndPhoneAlreadyExist()
    {
        // Arrange
        _cacheService
            .SetupSequence(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(true) // Email exists
            .ReturnsAsync(true); // Phone exists

        // Act
        var result = await _service.AddAsync(CreateDto());

        // Assert
        Assert.True(result.IsFailure);

        /*
         * Your Result implementation stores:
         *
         * MainError = Email error
         * Errors = Phone error
         *
         * Therefore Errors.Count == 1.
         */
        Assert.Equal(1, result.Errors.Count);

        _unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }


    [Fact]
    public async Task AddAsync_Should_ReturnSuccess_When_UserIsAdded()
    {
        // Arrange
        ArrangeSuccessScenario();

        // Act
        var result = await _service.AddAsync(CreateDto());

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion

    #region UpdateAsync
    [Fact]
    public async Task UpdateAsync_Should_Update_User_When_User_Exist()
    {
        //Arrange
        var userId = Guid.NewGuid();

        var user = new Modules.User.Domain.Entities.User
        {
            Id = userId,
            Name = "Mohammed",
            Email = "old@test.com",
            Phone = "123456789",
            DateOfBirth = new DateTime(2000, 1, 1),
            Gender = true
        };

        var dto = new UpdateUserDTO
        {
            Id = userId,
            Name = "Ahmed",
            DateOfBirth = new DateTime(1999, 5, 10),
            gender = false
        };

        _genericRepository
    .Setup(x => x.GetByIdAsync(dto.Id))
    .ReturnsAsync(user);

        _genericRepository
            .Setup(x => x.UpdateAsync(It.IsAny<Modules.User.Domain.Entities.User>()))
            .ReturnsAsync(true);
        // Act
        var result = await _service.UpdateAsync(dto);

        //Assert
        result.IsSuccess.Should().BeTrue();

        user.Name.Should().Be(dto.Name);
        user.DateOfBirth.Should().Be(dto.DateOfBirth);

        _genericRepository.Verify(
            x => x.GetByIdAsync(dto.Id),
            Times.Once);

        _genericRepository.Verify(
            x => x.UpdateAsync(user),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Return_NotFound_When_User_Does_Not_Exist()
    {
        // Arrange

        var dto = new UpdateUserDTO
        {
            Id = Guid.NewGuid(),
            Name = "Ahmed",
            DateOfBirth = new DateTime(1999, 5, 10),
            gender = false
        };

        _genericRepository
            .Setup(x => x.GetByIdAsync(dto.Id))
            .ReturnsAsync((Modules.User.Domain.Entities.User?)null);
        // Act

        var result = await _service.UpdateAsync(dto);

        // Assert

        result.IsSuccess.Should().BeFalse();

        _genericRepository.Verify(
            x => x.GetByIdAsync(dto.Id),
            Times.Once);

        _genericRepository.Verify(
            x => x.UpdateAsync(It.IsAny<Modules.User.Domain.Entities.User>()),
            Times.Never);
    }


   
    #endregion


    #region Helpers

    private AddUserDTO CreateDto()
    {
        return new AddUserDTO
        {
            Name = "Mohammed",
            Email = "test@test.com",
            Phone = "123456789",
            SchoolID = Guid.NewGuid(),
            DateOfBirth = new DateTime(2000, 1, 1),
            gender = true
        };
    }


    private void ArrangeSuccessScenario()
    {
        // Email doesn't exist
        // Phone doesn't exist
        _cacheService
            .Setup(x => x.GetOrCreateAsync(
                It.IsAny<string>(),
                It.IsAny<Func<Task<bool>>>(),
                It.IsAny<TimeSpan>()))
            .ReturnsAsync(false);


        // SchoolAdmin role exists
        _roleService
            .Setup(x => x.GetByCodeAsync(RoleCodes.SchoolAdmin))
            .ReturnsAsync(
                Result<RoleDTO?>.Success(
                    new RoleDTO
                    {
                        Id = Guid.NewGuid()
                    }));


        // Database save succeeds
        _unitOfWork
            .Setup(x => x.SaveChangesAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);
    }

    #endregion
}
