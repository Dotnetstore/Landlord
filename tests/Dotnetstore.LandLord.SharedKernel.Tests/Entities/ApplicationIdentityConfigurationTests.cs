using Dotnetstore.LandLord.SharedKernel.Entities;
using Dotnetstore.LandLord.SharedKernel.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;
using ApplicationIdentity = Dotnetstore.LandLord.SharedKernel.Entities.ApplicationIdentity;

namespace Dotnetstore.LandLord.SharedKernel.Tests.Entities;

public class ApplicationIdentityConfigurationTests
{
    private IMutableEntityType _entityType;

    private class TestPerson : ApplicationIdentity;
    private class TestPersonConfiguration : ApplicationIdentityConfiguration<TestPerson>;
    
    public ApplicationIdentityConfigurationTests()
    {
        var builder = new ModelBuilder();
        var entityTypeBuilder = builder.Entity<TestPerson>();
        var configuration = new TestPersonConfiguration();
        
        configuration.Configure(entityTypeBuilder);
        _entityType = entityTypeBuilder.Metadata;
    }
    
    [Fact]
    public void ApplicationIdentityConfiguration_Username_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("Username").Should().NotBeNull();
        _entityType.FindProperty("Username")!.IsNullable.Should().BeFalse();
        _entityType.FindProperty("Username")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxUsernameLength);
        _entityType.FindProperty("Username")!.IsUnicode().Should().BeFalse();
    }
    
    [Fact]
    public void ApplicationIdentityConfiguration_Password_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("Password").Should().NotBeNull();
        _entityType.FindProperty("Password")!.IsNullable.Should().BeFalse();
        _entityType.FindProperty("Password")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxPasswordLength);
        _entityType.FindProperty("Password")!.IsUnicode().Should().BeFalse();
    }
    
    [Fact]
    public void ApplicationIdentityConfiguration_RefreshToken_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("RefreshToken").Should().NotBeNull();
        _entityType.FindProperty("RefreshToken")!.IsNullable.Should().BeTrue();
        _entityType.FindProperty("RefreshToken")!.GetMaxLength().Should().Be(DataSchemeConstants.MaxRefreshTokenLength);
        _entityType.FindProperty("RefreshToken")!.IsUnicode().Should().BeFalse();
    }
    
    [Fact]
    public void ApplicationIdentityConfiguration_RefreshTokenExpiryTime_ShouldHaveCorrectConfiguration()
    {
        // Assert
        _entityType.Should().NotBeNull();
        _entityType.FindProperty("RefreshTokenExpiryTime").Should().NotBeNull();
        _entityType.FindProperty("RefreshTokenExpiryTime")!.IsNullable.Should().BeTrue();
    }
}