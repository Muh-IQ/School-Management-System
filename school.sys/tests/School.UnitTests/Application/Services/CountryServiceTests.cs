
using Modules.School.Application.IServices;
using Modules.School.Application.Services;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Moq;
using Xunit;

namespace School.UnitTests.Application.Services
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryRepository> _repositoryMock;
        private readonly CountryService _service;

        public CountryServiceTests()
        {
            _repositoryMock = new Mock<ICountryRepository>();
            _service = new CountryService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAsync_WhenNoCountriesExist_ShouldReturnFailure()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetAsync())
                .ReturnsAsync(new List<CountryDTO>());

            // Act
            var result = await _service.GetAsync();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorType.NotFound, result.Errors[0].ErrorType);
        }

        [Fact]
        public async Task GetAsync_WhenCountriesExist_ShouldReturnSuccess()
        {
            // Arrange
            var countries = new List<CountryDTO>
        {
            new CountryDTO { Id = Guid.NewGuid(), Name = "Iraq" },
            new CountryDTO { Id = Guid.NewGuid(), Name = "USA" }
        };

            _repositoryMock
                .Setup(r => r.GetAsync())
                .ReturnsAsync(countries);

            // Act
            var result = await _service.GetAsync();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(2, result.Value.Count());
        }
    }

}
