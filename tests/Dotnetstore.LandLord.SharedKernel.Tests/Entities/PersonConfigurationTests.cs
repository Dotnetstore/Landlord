using Dotnetstore.LandLord.SharedKernel.Entities;
using Dotnetstore.LandLord.SharedKernel.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.LandLord.SharedKernel.Tests.Entities;

public class PersonConfigurationTests
{
    private IMutableEntityType _entityType;

    private class TestPerson : Person;
    private class TestPersonConfiguration : PersonConfiguration<TestPerson>;
    
    public PersonConfigurationTests()
    {
        var builder = new ModelBuilder();
        var entityTypeBuilder = builder.Entity<TestPerson>();
        var configuration = new TestPersonConfiguration();
        
        configuration.Configure(entityTypeBuilder);
        _entityType = entityTypeBuilder.Metadata;
    }
    
    [Fact]
    public void PersonConfiguration_LastName_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("LastName").Should().NotBeNull();
        _entityType.FindProperty("LastName")!.IsNullable.Should().BeFalse();
        _entityType.FindProperty("LastName")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxPersonNameLength);
        _entityType.FindProperty("LastName")!.IsUnicode().Should().BeTrue();
    }
    
    [Fact]
    public void PersonConfiguration_FirstName_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("FirstName").Should().NotBeNull();
        _entityType.FindProperty("FirstName")!.IsNullable.Should().BeFalse();
        _entityType.FindProperty("FirstName")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxPersonNameLength);
        _entityType.FindProperty("FirstName")!.IsUnicode().Should().BeTrue();
    }
    
    [Fact]
    public void PersonConfiguration_MiddleName_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("MiddleName").Should().NotBeNull();
        _entityType.FindProperty("MiddleName")!.IsNullable.Should().BeTrue();
        _entityType.FindProperty("MiddleName")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxPersonNameLength);
        _entityType.FindProperty("MiddleName")!.IsUnicode().Should().BeTrue();
    }
    
    [Fact]
    public void PersonConfiguration_SocialSecurityNumber_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("SocialSecurityNumber").Should().NotBeNull();
        _entityType.FindProperty("SocialSecurityNumber")!.IsNullable.Should().BeTrue();
        _entityType.FindProperty("SocialSecurityNumber")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxSocialSecurityNumberLength);
        _entityType.FindProperty("SocialSecurityNumber")!.IsUnicode().Should().BeFalse();
    }
    
    [Fact]
    public void PersonConfiguration_IsMale_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("IsMale").Should().NotBeNull();
        _entityType.FindProperty("IsMale")!.IsNullable.Should().BeFalse();
    }
}