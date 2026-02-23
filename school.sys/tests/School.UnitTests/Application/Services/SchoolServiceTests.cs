using FluentAssertions;
using Modules.School.Application.Services;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using Moq;
using Xunit;
using SchoolEntity = Modules.School.Domain.Entities.School;

namespace School.UnitTests.Application.Services;

public class SchoolServiceTests
{
    private readonly Mock<IGenericRepository<SchoolEntity>> _repositoryMock;
    private readonly Mock<ISchoolRepository> _schoolRepositoryMock;
    private readonly SchoolService _sut;

    public SchoolServiceTests()
    {
        _repositoryMock = new Mock<IGenericRepository<SchoolEntity>>();
        _schoolRepositoryMock = new Mock<ISchoolRepository>();
        _sut = new SchoolService(_repositoryMock.Object, _schoolRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_WhenContactIsUnique_ReturnsSuccess()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "school@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "Policy",
            PolicyDescription = "Desc",
            PolicyType = "Type"
        };

        _repositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<SchoolEntity>())).ReturnsAsync(true);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
    }

    [Fact]
    public async Task CreateAsync_WhenEmailExists_ReturnsConflict()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "existing@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "P",
            PolicyDescription = "D",
            PolicyType = "T"
        };

        _repositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.Conflict);
        result.Errors[0].Message.Should().Contain("existing@test.com");
    }

    [Fact]
    public async Task CreateAsync_WhenPhoneExists_ReturnsConflict()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "new@test.com",
            Phone = "+9999999999",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "P",
            PolicyDescription = "D",
            PolicyType = "T"
        };

        _repositoryMock.SetupSequence(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false)
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.Conflict);
        result.Errors[0].Message.Should().Contain("+9999999999");
    }

    [Fact]
    public async Task CreateAsync_WhenAddFails_ReturnsInternalServerError()
    {
        var dto = new SchoolAddCommand
        {
            Name = "Test School",
            Email = "school@test.com",
            Phone = "+1234567890",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "P",
            PolicyDescription = "D",
            PolicyType = "T"
        };

        _repositoryMock.Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<SchoolEntity>())).ReturnsAsync(false);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.InternalServerError);
    }

    [Fact]
    public async Task GetByIdAsync_WhenSchoolExists_ReturnsSchool()
    {
        var id = Guid.NewGuid();
        var school = new SchoolEntity { Id = id, Name = "Test", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(school);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value!.Id.Should().Be(id);
    }
    [Fact]
    public async Task GetByIdAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task GetByIdAsDtoAsync_WhenNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _schoolRepositoryMock.Setup(r => r.GetByIdAsDtoAsync(id)).ReturnsAsync((SchoolDetailsDTO?)null);

        var result = await _sut.GetByIdAsDtoAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        var dto = new SchoolUpdateCommand { Name = "New", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.UpdateAsync(id, dto);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_WhenSchoolNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((SchoolEntity?)null);

        var result = await _sut.DeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_WhenDeleteFails_ReturnsInternalServerError()
    {
        var id = Guid.NewGuid();
        var school = new SchoolEntity { Id = id, Name = "T", Email = "e@e.com", Phone = "1", LanguageId = Guid.NewGuid(), PolicyId = Guid.NewGuid() };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(school);
        _repositoryMock.Setup(r => r.DeleteAsync(school)).ReturnsAsync(false);

        var result = await _sut.DeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.InternalServerError);
    }
}
