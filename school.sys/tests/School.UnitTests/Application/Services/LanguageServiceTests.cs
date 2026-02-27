using FluentAssertions;
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

public class LanguageServiceTests
{
    private readonly Mock<IGenericRepository<LanguageEntity>> _repositoryMock;
    private readonly Mock<ILanguageRepository> _languageRepositoryMock;
    private readonly Mock<IGenericRepository<SchoolEntity>> _schoolRepositoryMock;
    private readonly LanguageService _sut;

    public LanguageServiceTests()
    {
        _repositoryMock = new Mock<IGenericRepository<LanguageEntity>>();
        _languageRepositoryMock = new Mock<ILanguageRepository>();
        _schoolRepositoryMock = new Mock<IGenericRepository<SchoolEntity>>();
        _sut = new LanguageService(
            _repositoryMock.Object,
            _languageRepositoryMock.Object,
            _schoolRepositoryMock.Object);
    }

    #region CreateAsync

    [Fact]
    public async Task CreateAsync_WhenLanguageIsNull_ReturnsBadRequest()
    {
        var result = await _sut.CreateAsync(null!);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.BadRequest);
    }

    [Fact]
    public async Task CreateAsync_WhenNameIsEmpty_ReturnsValidation()
    {
        var language = new LanguageEntity { Name = "  ", Code = "en" };

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task CreateAsync_WhenCodeIsEmpty_ReturnsValidation()
    {
        var language = new LanguageEntity { Name = "English", Code = "" };

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task CreateAsync_WhenNameAlreadyExists_ReturnsConflict()
    {
        var language = new LanguageEntity { Name = "English", Code = "en" };
        _repositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task CreateAsync_WhenCodeAlreadyExists_ReturnsConflict()
    {
        var language = new LanguageEntity { Name = "English", Code = "en" };
        _repositoryMock
            .SetupSequence(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(false)
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task CreateAsync_WhenAddFails_ReturnsInternalServerError()
    {
        var language = new LanguageEntity { Name = "English", Code = "en" };
        _repositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<LanguageEntity>()))
            .ReturnsAsync(false);

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.InternalServerError);
    }

    [Fact]
    public async Task CreateAsync_WhenValid_ReturnsSuccessAndAddsLanguage()
    {
        var language = new LanguageEntity { Name = "English", Code = "en" };
        _repositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<LanguageEntity>()))
            .ReturnsAsync(true);

        var result = await _sut.CreateAsync(language);

        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<LanguageEntity>()), Times.Once);
    }

    #endregion

    #region GetByIdAsync

    [Fact]
    public async Task GetByIdAsync_WhenNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _languageRepositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((LanguageDTO?)null);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_WhenFound_ReturnsSuccessWithDto()
    {
        var id = Guid.NewGuid();
        var dto = new LanguageDTO { Id = id, Name = "English" };
        _languageRepositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(dto);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value!.Id.Should().Be(id);
        result.Value.Name.Should().Be("English");
    }

    #endregion

    #region GetAllAsync

    [Fact]
    public async Task GetAllAsync_WhenRepositoryReturnsNull_ReturnsInternalServerError()
    {
        _languageRepositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync((IEnumerable<LanguageDTO>?)null!);

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.InternalServerError);
    }

    [Fact]
    public async Task GetAllAsync_WhenLanguagesExist_ReturnsSuccessWithList()
    {
        var list = new List<LanguageDTO>
        {
            new() { Id = Guid.NewGuid(), Name = "English" },
            new() { Id = Guid.NewGuid(), Name = "Arabic" }
        };
        _languageRepositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(list);

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value!.Count().Should().Be(2);
    }

    [Fact]
    public async Task GetAllAsync_WhenEmpty_ReturnsSuccessWithEmptyList()
    {
        _languageRepositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<LanguageDTO>());

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull().And.BeEmpty();
    }

    #endregion

    #region GetPagedAsync

    [Theory]
    [InlineData(0, 10)]
    [InlineData(1, 0)]
    [InlineData(1, 101)]
    public async Task GetPagedAsync_WhenInvalidPaging_ReturnsValidation(int paging, int pageSize)
    {
        var result = await _sut.GetPagedAsync(paging, pageSize);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task GetPagedAsync_WhenValid_ReturnsSuccessWithPage()
    {
        var list = new List<LanguageDTO> { new() { Id = Guid.NewGuid(), Name = "English" } };
        _languageRepositoryMock
            .Setup(r => r.GetPagedAsync(1, 10))
            .ReturnsAsync(list);

        var result = await _sut.GetPagedAsync(1, 10);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull().And.HaveCount(1);
    }

    #endregion

    #region UpdateAsync

    [Fact]
    public async Task UpdateAsync_WhenLanguageIsNull_ReturnsBadRequest()
    {
        var result = await _sut.UpdateAsync(null!);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_WhenIdIsEmpty_ReturnsValidation()
    {
        var language = new LanguageEntity { Id = Guid.Empty, Name = "English", Code = "en" };

        var result = await _sut.UpdateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task UpdateAsync_WhenEntityNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, Name = "English", Code = "en" };
        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((LanguageEntity?)null!);

        var result = await _sut.UpdateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_WhenEntityIsDeleted_ReturnsConflict()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, Name = "English", Code = "en" };
        var existing = new LanguageEntity { Id = id, Name = "Old", Code = "en", IsDeleted = true };
        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((LanguageEntity?)existing);

        var result = await _sut.UpdateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task UpdateAsync_WhenNameTakenByOther_ReturnsConflict()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, Name = "Arabic", Code = "en" };
        var existing = new LanguageEntity { Id = id, Name = "English", Code = "en" };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageEntity?)existing);
        _repositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(true);

        var result = await _sut.UpdateAsync(language);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task UpdateAsync_WhenValid_ReturnsSuccessAndUpdates()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, Name = "English Updated", Code = "en" };
        var existing = new LanguageEntity { Id = id, Name = "English", Code = "en" };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageEntity?)existing);
        _repositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LanguageEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<LanguageEntity>()))
            .ReturnsAsync(true);

        var result = await _sut.UpdateAsync(language);

        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<LanguageEntity>()), Times.Once);
    }

    #endregion

    #region SoftDeleteAsync

    [Fact]
    public async Task SoftDeleteAsync_WhenLanguageNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((LanguageEntity?)null!);

        var result = await _sut.SoftDeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task SoftDeleteAsync_WhenAlreadyDeleted_ReturnsConflict()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, IsDeleted = true };
        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((LanguageEntity?)language);

        var result = await _sut.SoftDeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task SoftDeleteAsync_WhenInUseBySchool_ReturnsConflict()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, IsDeleted = false, IsActive = true };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageEntity?)language);
        _schoolRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(true);

        var result = await _sut.SoftDeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.Conflict);
    }

    [Fact]
    public async Task SoftDeleteAsync_WhenUpdateFails_ReturnsInternalServerError()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, IsDeleted = false, IsActive = true };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageEntity?)language);
        _schoolRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<LanguageEntity>()))
            .ReturnsAsync(false);

        var result = await _sut.SoftDeleteAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].ErrorType.Should().Be(ErrorType.InternalServerError);
    }

    [Fact]
    public async Task SoftDeleteAsync_WhenValid_ReturnsSuccessAndSoftDeletes()
    {
        var id = Guid.NewGuid();
        var language = new LanguageEntity { Id = id, IsDeleted = false, IsActive = true };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageEntity?)language);
        _schoolRepositoryMock
            .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
            .ReturnsAsync(false);
        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<LanguageEntity>()))
            .ReturnsAsync(true);

        var result = await _sut.SoftDeleteAsync(id);

        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<LanguageEntity>()), Times.Once);
    }

    #endregion
}
