using FluentAssertions;
using Modules.School.Application.Mappers;
using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;
using Xunit;

namespace School.UnitTests.Application.Mappers;

public class SchoolMapperTests
{
    [Fact]
    public void MapSchoolAddDTOToEntity_WithValidDto_MapsCorrectly()
    {
        var langId = Guid.NewGuid();
        var dto = new SchoolAddDTO
        {
            Name = "My School Name",
            Email = "school@example.com",
            Phone = "+1234567890",
            LanguageId = langId,
            PolicyTitle = "Custom Policy",
            PolicyDescription = "Description",
            PolicyType = "Custom"
        };

        var entity = SchoolMapper.MapSchoolAddDTOToEntity(dto);

        entity.Should().NotBeNull();
        entity.Id.Should().NotBe(Guid.Empty);
        entity.Name.Should().Be("My School Name");
        entity.sanitizeName.Should().Be("my-school-name");
        entity.Email.Should().Be("school@example.com");
        entity.Phone.Should().Be("+1234567890");
        entity.LanguageId.Should().Be(langId);
        entity.IsActive.Should().BeTrue();
        entity.IsDeleted.Should().BeFalse();
        entity.Policy.Should().NotBeNull();
        entity.Policy!.Title.Should().Be("Custom Policy");
        entity.Policy.PolicyType.Should().Be("Custom");
    }

    [Fact]
    public void MapSchoolAddDTOToEntity_WithEmptyPolicy_UsesDefaultPolicy()
    {
        var dto = new SchoolAddDTO
        {
            Name = "School",
            Email = "e@e.com",
            Phone = "1",
            LanguageId = Guid.NewGuid(),
            PolicyTitle = "",
            PolicyDescription = "",
            PolicyType = ""
        };

        var entity = SchoolMapper.MapSchoolAddDTOToEntity(dto);

        entity.Policy.Should().NotBeNull();
        entity.Policy!.Title.Should().Be("Master Policy");
        entity.Policy.PolicyType.Should().Be("Master");
    }

    [Fact]
    public void MapSchoolUpdateDTOToEntity_UpdatesEntityInPlace()
    {
        var entity = new Modules.School.Domain.Entities.School
        {
            Id = Guid.NewGuid(),
            Name = "Old Name",
            sanitizeName = "old-name",
            Email = "old@e.com",
            Phone = "111",
            LanguageId = Guid.NewGuid(),
            PolicyId = Guid.NewGuid()
        };
        var langId = Guid.NewGuid();
        var policyId = Guid.NewGuid();
        var dto = new SchoolUpdateDTO
        {
            Name = "Updated School",
            Email = "new@e.com",
            Phone = "+999",
            LanguageId = langId,
            PolicyId = policyId
        };

        SchoolMapper.MapSchoolUpdateDTOToEntity(dto, entity);

        entity.Name.Should().Be("Updated School");
        entity.sanitizeName.Should().Be("updated-school");
        entity.Email.Should().Be("new@e.com");
        entity.Phone.Should().Be("+999");
        entity.LanguageId.Should().Be(langId);
        entity.PolicyId.Should().Be(policyId);
    }
}
