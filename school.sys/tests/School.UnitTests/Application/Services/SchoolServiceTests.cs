using FluentAssertions;
using Modules.School.Application.IServices;
using Modules.School.Application.Services;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using Moq;
using System.Linq.Expressions;
using Xunit;
using LanguageEntity = Modules.School.Domain.Entities.Language;
using SchoolEntity = Modules.School.Domain.Entities.School;

namespace School.UnitTests.Application.Services;

public class SchoolServiceTests
{
    private readonly Mock<ISchoolRepository> _schoolRepositoryMock;
    private readonly Mock<IPolicyRepository> _policyRepositoryMock;

    private readonly Mock<IGenericRepository<LanguageEntity>> _languageRepositoryMock;
    private readonly Mock<ICacheService> _cacheService;

    private readonly SchoolService _sut;

    public SchoolServiceTests()
    {
        _schoolRepositoryMock = new Mock<ISchoolRepository>();
        _policyRepositoryMock = new Mock<IPolicyRepository>();
        _languageRepositoryMock = new Mock<IGenericRepository<LanguageEntity>>();
        _cacheService = new Mock<ICacheService>();
        _sut = new SchoolService(_schoolRepositoryMock.Object,_policyRepositoryMock.Object,
            _languageRepositoryMock.Object,_cacheService.Object);
    }
    
    ///////////////
   
    [Fact]
    public async Task CreateAsync_WhenPolicyInfoProvided_CreatesNewPolicy()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "school@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "Policy",
            PolicyDescription = "Description"
        };

        _languageRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Language, bool>>>()))
            .ReturnsAsync(true);

        _schoolRepositoryMock
            .SetupSequence(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false) 
            .ReturnsAsync(false); 

        _policyRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Policy>()))
            .ReturnsAsync(true);

        _schoolRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<SchoolEntity>()))
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();

        _policyRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Policy>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WhenPolicyInfoNotProvided_UsesDefaultPolicy()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "school@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = null,
            PolicyDescription = null
        };

        var defaultPolicyId = Guid.NewGuid();

        _languageRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Language, bool>>>()))
            .ReturnsAsync(true);

        _schoolRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);

        _policyRepositoryMock
            .Setup(r => r.GetDefaultPolicyIdAsync())
            .ReturnsAsync(defaultPolicyId);

        SchoolEntity? capturedSchool = null;

        _schoolRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<SchoolEntity>()))
            .Callback<SchoolEntity>(s => capturedSchool = s)
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();

        _policyRepositoryMock.Verify(r => r.GetDefaultPolicyIdAsync(), Times.Once);
        _policyRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Policy>()), Times.Never);

        capturedSchool.Should().NotBeNull();
        capturedSchool!.PolicyId.Should().Be(defaultPolicyId);
    }
    [Theory]
    [InlineData("Title", null)]
    [InlineData(null, "Description")]
    public async Task CreateAsync_WhenPolicyInfoIncomplete_ReturnsBadRequest(string? title, string? description)
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "school@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = title,
            PolicyDescription = description
        };

        _languageRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Language, bool>>>()))
            .ReturnsAsync(true);

        // Email + Phone are unique
        _schoolRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.BadRequest);
        result.Errors[0].Message.Should().Contain("Both PolicyTitle and PolicyDescription should be provided together");
    }

    //[Fact]
    //public async Task CreateAsync_WhenContactIsUnique_ReturnsSuccess()
    //{
    //    var dto = new SchoolAddCommand
    //    {
    //        Name = "Test School",
    //        Email = "school@test.com",
    //        Phone = "+1234567890",
    //        LanguageId = Guid.NewGuid(),
    //        PolicyTitle = "Policy",
    //        PolicyDescription = "Desc",
    //    };

    //    _schoolRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
    //        .ReturnsAsync(false);
    //    _schoolRepositoryMock.Setup(r => r.AddAsync(It.IsAny<SchoolEntity>())).ReturnsAsync(true);

    //    var result = await _sut.CreateAsync(dto);

    //    result.IsSuccess.Should().BeTrue();
    //    result.IsFailure.Should().BeFalse();
    //}

    //[Fact]
    //public async Task CreateAsync_WhenEmailExists_ReturnsConflict()
    //{
    //    var dto = new SchoolAddCommand
    //    {
    //        Name = "Test School",
    //        Email = "existing@test.com",
    //        Phone = "+1234567890",
    //        LanguageId = Guid.NewGuid(),
    //        PolicyTitle = "P",
    //        PolicyDescription = "D",
    //    };

    //    _schoolRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
    //        .ReturnsAsync(true);

    //    var result = await _sut.CreateAsync(dto);

    //    result.IsSuccess.Should().BeFalse();
    //    result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.Conflict);
    //    result.Errors[0].Message.Should().Contain("existing@test.com");
    //}

    //[Fact]
    //public async Task CreateAsync_WhenPhoneExists_ReturnsConflict()
    //{
    //    var dto = new SchoolAddCommand
    //    {
    //        Name = "Test School",
    //        Email = "new@test.com",
    //        Phone = "+9999999999",
    //        LanguageId = Guid.NewGuid(),
    //        PolicyTitle = "P",
    //        PolicyDescription = "D",
    //    };

    //    _schoolRepositoryMock.SetupSequence(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
    //        .ReturnsAsync(false)
    //        .ReturnsAsync(true);

    //    var result = await _sut.CreateAsync(dto);

    //    result.IsSuccess.Should().BeFalse();
    //    result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.Conflict);
    //    result.Errors[0].Message.Should().Contain("+9999999999");
    //}

    //[Fact]
    //public async Task CreateAsync_WhenAddFails_ReturnsInternalServerError()
    //{
    //    var dto = new SchoolAddCommand
    //    {
    //        Name = "Test School",
    //        Email = "school@test.com",
    //        Phone = "+1234567890",
    //        LanguageId = Guid.NewGuid(),
    //        PolicyTitle = "P",
    //        PolicyDescription = "D",
    //    };

    //    _schoolRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
    //        .ReturnsAsync(false);
    //    _schoolRepositoryMock.Setup(r => r.AddAsync(It.IsAny<SchoolEntity>())).ReturnsAsync(false);

    //    var result = await _sut.CreateAsync(dto);

    //    result.IsSuccess.Should().BeFalse();
    //    result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.InternalServerError);
    //}

    //[Fact]
    //public async Task GetByIdAsync_WhenSchoolExists_ReturnsSchool()
    //{
    //    var id = Guid.NewGuid();
    //    var school = new SchoolEntity { Id = id, Name = "Test", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
    //    _schoolRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(school);

    //    var result = await _sut.GetByIdAsync(id);

    //    result.IsSuccess.Should().BeTrue();
    //    result.Value.Should().NotBeNull();
    //    result.Value!.Id.Should().Be(id);
    //}
    [Fact]
    public async Task GetByIdAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _schoolRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task GetByIdAsDtoAsync_WhenNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _schoolRepositoryMock.Setup(r => r.GetByIdAsDtoAsync(id)).ReturnsAsync((SchoolDetailsDTO?)null);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        var dto = new SchoolUpdateCommand { Name = "New", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
        _schoolRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.UpdateAsync(id, dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _schoolRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.DeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_WhenDeleteFails_ReturnsInternalServerError()
    {
        var id = Guid.NewGuid();
        var school = new SchoolEntity { Id = id, Name = "T", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
        _schoolRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(school);
        //_schoolRepositoryMock.Setup(r => r.DeleteAsync(school)).ReturnsAsync(false);

        var result = await _sut.DeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.InternalServerError);
    }
}
