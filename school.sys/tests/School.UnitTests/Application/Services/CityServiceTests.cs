using FluentAssertions;
using Modules.School.Application.IServices;
using Modules.School.Application.Services;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.IRepositories;
using Moq;
using Xunit;
namespace School.UnitTests.Application.Services
{
        public class CityServiceTests
        {
            private readonly Mock<ICityRepository> _repositoryMock;
            private readonly ICityService _cityService;

            public CityServiceTests()
            {
                _repositoryMock = new Mock<ICityRepository>();
                _cityService = new CityService(_repositoryMock.Object);
            }

            [Fact]
            public async Task GetAllByIdAsync_ShouldReturnSuccess_WhenCitiesExist()
            {
                // Arrange
                var countryId = Guid.NewGuid();
                var cities = new List<LocationDTO>
                {
                    new LocationDTO { Id = Guid.NewGuid(), Name = "City A" },
                    new LocationDTO { Id = Guid.NewGuid(), Name = "City B" }
                };

                _repositoryMock
                    .Setup(r => r.GetAllByIdAsync(countryId))
                    .ReturnsAsync(cities);

                // Act
                var result = await _cityService.GetAllByIdAsync(countryId);

                // Assert
                result.IsSuccess.Should().BeTrue();
                result.Value.Should().BeEquivalentTo(cities);
            }

            [Fact]
            public async Task GetAllByIdAsync_ShouldReturnFailure_WhenNoCitiesFound()
            {
                // Arrange
                var countryId = Guid.NewGuid();
                _repositoryMock
                    .Setup(r => r.GetAllByIdAsync(countryId))
                    .ReturnsAsync(new List<LocationDTO>()); // empty list

                // Act
                var result = await _cityService.GetAllByIdAsync(countryId);

                // Assert
                result.IsFailure.Should().BeTrue();
                result.Errors.Should().ContainSingle()
                    .Which.ErrorType.Should().Be(ErrorType.NotFound);
            }

        }
}
