using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Application.Services;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.Entities;
using Modules.User.Domain.IRepositories;
using Modules.User.Domain.Utilities;
using Moq;
using SharedKernel;
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
    private readonly MicroBatch<Modules.User.Domain.Entities.User> _userBatcher;
    private readonly MicroBatch<Modules.User.Domain.Entities.UserRole> _userRoleBatcher;

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
        _userBatcher = new MicroBatch<Modules.User.Domain.Entities.User>(
            100,
            TimeSpan.FromSeconds(10),
            async users => { });

        _userRoleBatcher = new MicroBatch<Modules.User.Domain.Entities.UserRole>(
            100,
            TimeSpan.FromSeconds(10),
            async userRoles => { });

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
            _userRoleBatcher,
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


    [Fact]
    public async Task AddAsync_Should_ReturnFailure_When_SaveChangesFails()
    {
        // Arrange
        ArrangeSuccessScenario();

        _unitOfWork
            .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(0);

        // Act
        var result = await _service.AddAsync(CreateDto());

        // Assert
        Assert.True(result.IsFailure);

        Assert.Equal(
            ErrorType.InternalServerError,
            result.MainError.ErrorType);

        Assert.Equal(
            "Failed to add user",
            result.MainError.Message);
    }


    [Fact]
    public async Task AddAsync_Should_Insert_User()
    {
        // Arrange
        ArrangeSuccessScenario();

        // Act
        await _service.AddAsync(CreateDto());

        // Assert
        _userRepository.Verify(
            x => x.StageInsert(It.IsAny<user.User>()),
            Times.Once);
    }


    [Fact]
    public async Task AddAsync_Should_Insert_UserRole()
    {
        // Arrange
        ArrangeSuccessScenario();

        // Act
        await _service.AddAsync(CreateDto());

        // Assert
        _userRoleRepository.Verify(
            x => x.StageInsert(It.IsAny<UserRole>()),
            Times.Once);
    }


    [Fact]
    public async Task AddAsync_Should_Call_SaveChanges_Once()
    {
        // Arrange
        ArrangeSuccessScenario();

        // Act
        await _service.AddAsync(CreateDto());

        // Assert
        _unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
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