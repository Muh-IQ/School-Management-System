using FluentAssertions;
using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.Sessions;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.Helpers;
using Modules.IdP.Application.IServices;
using Modules.IdP.Application.Services;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.Domain.Utilities;
using Moq;
using SharedKernel;
using SharedKernel.Events;
using System.Linq.Expressions;
using Xunit;

using user = Modules.IdP.Domain.Entities;

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
    private readonly MicroBatch<Modules.IdP.Domain.BatchRecord.UserRegistrationBatchItem> _userBatcher;
    //private readonly MicroBatch<Modules.IdP.Domain.Entities.UserRole> _userRoleBatcher;

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
        _userBatcher = new MicroBatch<Modules.IdP.Domain.BatchRecord.UserRegistrationBatchItem>(
            100,
            TimeSpan.FromSeconds(10),
            async users => { });

        //_userRoleBatcher = new MicroBatch<Modules.IdP.Domain.Entities.UserRole>(
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

        var user = new Modules.IdP.Domain.Entities.User
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
            .Setup(x => x.UpdateAsync(It.IsAny<Modules.IdP.Domain.Entities.User>()))
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
            .ReturnsAsync((Modules.IdP.Domain.Entities.User?)null);
        // Act

        var result = await _service.UpdateAsync(dto);

        // Assert

        result.IsSuccess.Should().BeFalse();

        _genericRepository.Verify(
            x => x.GetByIdAsync(dto.Id),
            Times.Once);

        _genericRepository.Verify(
            x => x.UpdateAsync(It.IsAny<Modules.IdP.Domain.Entities.User>()),
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
