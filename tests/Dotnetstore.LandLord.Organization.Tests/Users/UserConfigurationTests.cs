using Dotnetstore.LandLord.Organization.Users;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Users;

public class UserConfigurationTests
{
    private IMutableEntityType _entityType;
    
    public UserConfigurationTests()
    {
        var builder = new ModelBuilder();
        var entityTypeBuilder = builder.Entity<User>();
        var configuration = new UserConfiguration();
        
        configuration.Configure(entityTypeBuilder);
        _entityType = entityTypeBuilder.Metadata;
    }
    
    [Fact]
    public void UserConfiguration_Id_ShouldHaveCorrectConfiguration()
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
    public void UserConfiguration_OfficeId_ShouldHaveCorrectConfiguration()
    {
        // Assert
        using (new AssertionScope())
        {
            _entityType.Should().NotBeNull();
            _entityType.FindProperty("OfficeId").Should().NotBeNull();
            _entityType.FindProperty("OfficeId")!.IsNullable.Should().BeFalse();
            _entityType.FindProperty("OfficeId")!.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }
}