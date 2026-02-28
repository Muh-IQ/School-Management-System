using FluentAssertions;
using Modules.School.Application.IServices;
using Modules.School.Application.Services;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities.Place;
using Modules.School.Domain.IRepositories;
using Moq;
using Xunit;

namespace School.UnitTests.Application.Services
{
    public class AreaServiceTests
    {
        private readonly Mock<IAreaRepository> _repoMock;
        private readonly AreaService _service;

        public AreaServiceTests()
        {
            _repoMock = new Mock<IAreaRepository>();
            _service = new AreaService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllByIdAsync_Should_Return_Failure_When_CityId_Is_Empty()
        {

            // Arrange
            var cityId = Guid.Empty;
            var countryId = Guid.NewGuid();

            // Act
            var result = await _service.GetAllByIdAsync(countryId,cityId);

            // Assert
            result.IsSuccess.Should().BeFalse();
            _repoMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(),It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task GetAllByIdAsync_Should_Return_Failure_When_No_Data_Found()
        {
            // Arrange
            var cityId = Guid.NewGuid();
            var countryId = Guid.NewGuid();


            _repoMock
                .Setup(x => x.GetByIdAsync(countryId, cityId))
                .ReturnsAsync(new List<LocationDTO>());

            // Act
            var result = await _service.GetAllByIdAsync(countryId, cityId);

            // Assert
            result.IsSuccess.Should().BeFalse();
            _repoMock.Verify(x => x.GetByIdAsync(countryId, cityId), Times.Once);
        }

        [Fact]
        public async Task GetAllByIdAsync_Should_Return_Success_When_Data_Exists()
        {
            // Arrange
            var cityId = Guid.NewGuid();
            var countryId = Guid.NewGuid();

            var data = new List<LocationDTO>
        {
            new LocationDTO { Id = Guid.NewGuid(), Name = "Area1" },
            new LocationDTO { Id = Guid.NewGuid(), Name = "Area2" }
        };

            _repoMock
                .Setup(x => x.GetByIdAsync(countryId, cityId))
                .ReturnsAsync(data);

            // Act
            var result = await _service.GetAllByIdAsync(countryId, cityId);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(2);
            _repoMock.Verify(x => x.GetByIdAsync(countryId, cityId), Times.Once);
        }
    }
}
