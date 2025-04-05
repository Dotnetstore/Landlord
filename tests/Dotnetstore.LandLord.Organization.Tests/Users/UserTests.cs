using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.Organization.Users;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Users;

public class UserTests
{
    [Fact]
    public void User_Should_ContainProperties()
    {
        // Arrange
        var type = typeof(User);
        
        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(User.Id) && x.PropertyType == typeof(UserId));
            properties.Should().ContainSingle(x => x.Name == nameof(User.OfficeId) && x.PropertyType == typeof(OfficeId));
        }
    }
}