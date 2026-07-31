using FluentAssertions;
using Modules.School.Application.Services;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Moq;
using Xunit;

namespace School.UnitTests.Application.Services;

public class LanguageServiceTests
{
    private readonly Mock<ILanguageRepository> _repositoryMock;
    private readonly LanguageService _sut;

    public LanguageServiceTests()
    {
        _repositoryMock = new Mock<ILanguageRepository>();
        _sut = new LanguageService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_WhenLanguageExists_ReturnsSuccessWithDto()
    {
        var id = Guid.NewGuid();
        var dto = new LanguageDTO { Id = id, Name = "English" };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(dto);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value!.Id.Should().Be(id);
        result.Value.Name.Should().Be("English");
        _repositoryMock.Verify(r => r.GetByIdAsync(id), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WhenLanguageNotFound_ReturnsNotFound()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LanguageDTO?)null);

        var result = await _sut.GetByIdAsync(id);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
        result.Errors[0].Message.Should().Be("Language Not Found.");
        _repositoryMock.Verify(r => r.GetByIdAsync(id), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_WhenLanguagesExist_ReturnsSuccessWithDtos()
    {
        var languages = new List<LanguageDTO>
        {
            new() { Id = Guid.NewGuid(), Name = "English" },
            new() { Id = Guid.NewGuid(), Name = "Arabic" }
        };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(languages);

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Should().HaveCount(2);
        result.Value!.Select(l => l.Name).Should().Contain(new[] { "English", "Arabic" });
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_WhenNoLanguages_ReturnsNotFound()
    {
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(Array.Empty<LanguageDTO>());

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
        result.Errors[0].Message.Should().Be("Languages Not Found.");
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_WhenRepositoryReturnsNull_ReturnsNotFound()
    {
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync((IEnumerable<LanguageDTO>?)null!);

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }
}
