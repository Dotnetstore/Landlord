using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.SharedKernel.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Offices;

public class OfficeConfigurationTests
{
    private IMutableEntityType _entityType;
    
    public OfficeConfigurationTests()
    {
        var builder = new ModelBuilder();
        var entityTypeBuilder = builder.Entity<Office>();
        var configuration = new OfficeConfiguration();
        
        configuration.Configure(entityTypeBuilder);
        _entityType = entityTypeBuilder.Metadata;
    }
    
    [Fact]
    public void OfficeConfiguration_Id_ShouldHaveCorrectConfiguration()
    {
        // Assert
        using (new AssertionScope())
        {
            _entityType.Should().NotBeNull();
            _entityType.FindProperty("Id").Should().NotBeNull();
            _entityType.FindIndex(_entityType.FindProperty("Id")!)!.IsUnique.Should().BeTrue();
            _entityType.FindPrimaryKey()!.Properties.Select(x => x.Name).Should().Contain("Id");
            _entityType.FindProperty("Id")!.ValueGenerated.Should().Be(ValueGenerated.Never);
            _entityType.FindProperty("Id")!.IsNullable.Should().BeFalse();
        }
    }
    
    [Fact]
    public void OfficeConfiguration_Name_ShouldHaveCorrectConfiguration()
    {
        // Assert
        using (new AssertionScope())
        {
            _entityType.Should().NotBeNull();
            _entityType.FindProperty("Name").Should().NotBeNull();
            _entityType.FindProperty("Name")!.IsNullable.Should().BeFalse();
            _entityType.FindProperty("Name")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxCompanyNameLength);
            _entityType.FindProperty("Name")!.IsNullable.Should().BeFalse();
            _entityType.FindProperty("Name")!.IsUnicode().Should().BeTrue();
        }
    }
    
    [Fact]
    public void OfficeConfiguration_CorporateId_ShouldHaveCorrectConfiguration()
    {
        // Assert
        using (new AssertionScope())
        {
            _entityType.Should().NotBeNull();
            _entityType.FindProperty("CorporateId").Should().NotBeNull();
            _entityType.FindProperty("CorporateId")!.IsNullable.Should().BeTrue();
            _entityType.FindProperty("CorporateId")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxSocialSecurityNumberLength);
            _entityType.FindProperty("CorporateId")!.IsNullable.Should().BeTrue();
            _entityType.FindProperty("CorporateId")!.IsUnicode().Should().BeFalse();
        }
    }
}