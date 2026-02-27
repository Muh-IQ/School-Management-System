using System;
using FluentAssertions;
using Modules.School.Application.Mappers;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Xunit;

namespace Modules.School.Tests.Mappers
{
    public class SchoolMapperTests
    {
        private readonly SchoolMapper _mapper;

        public SchoolMapperTests()
        {
            _mapper = new SchoolMapper();
        }

        [Fact]
        public void MapSchoolAddDTOToEntityPolicy_Should_Map_Correctly()
        {
            // Arrange
            string title = "Policy A";
            string description = "Policy Description";

            // Act
            var result = _mapper.MapSchoolAddDTOToEntityPolicy(title, description);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(title);
            result.Description.Should().Be(description);
            result.IsActive.Should().BeTrue();
            result.IsDeleted.Should().BeFalse();
            result.IsDefault.Should().BeFalse();
            result.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void MapSchoolAddDTOToEntity_Should_Map_Correctly()
        {
            // Arrange
            var dto = new SchoolAddCommand
            {
                Name = "My School",
                Email = "school@example.com",
                Phone = "1234567890",
                LanguageId = Guid.NewGuid() 
            };
            var policyId = Guid.NewGuid();

            // Act
            var result = _mapper.MapSchoolAddDTOToEntity(dto, policyId);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.Email.Should().Be(dto.Email);
            result.Phone.Should().Be(dto.Phone);
            result.LanguageId.Should().Be(dto.LanguageId); 
            result.PolicyId.Should().Be(policyId);
            result.IsActive.Should().BeTrue();
            result.IsDeleted.Should().BeFalse();
            result.Id.Should().NotBeEmpty();
            result.TimeZone.Should().MatchRegex(@"^[+-][0-1][0-9]:[0-5][0-9]$|^\+2[0-3]:[0-5][0-9]$");
        }

        [Fact]
        public void MapSchoolUpdateDTOToEntity_Should_Update_Existing_Entity()
        {
            // Arrange
            var entity = new Domain.Entities.School
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                Email = "old@example.com",
                Phone = "0000000000",
                LanguageId = Guid.NewGuid(), 
                PolicyId = Guid.NewGuid()
            };

            var updateDto = new SchoolUpdateCommand
            {
                Name = "New Name",
                Email = "new@example.com",
                Phone = "1111111111",
                LanguageId = Guid.NewGuid(), 
                PolicyId = Guid.NewGuid()
            };

            // Act
            _mapper.MapSchoolUpdateDTOToEntity(updateDto, entity);

            // Assert
            entity.Name.Should().Be(updateDto.Name);
            entity.Email.Should().Be(updateDto.Email);
            entity.Phone.Should().Be(updateDto.Phone);
            entity.LanguageId.Should().Be(updateDto.LanguageId); 
            entity.PolicyId.Should().Be(updateDto.PolicyId);
        }
    }
}