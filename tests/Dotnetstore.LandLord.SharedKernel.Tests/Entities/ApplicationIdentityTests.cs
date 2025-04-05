using FluentAssertions;
using Xunit;

namespace Dotnetstore.LandLord.SharedKernel.Tests.Entities;

public class ApplicationIdentityTests
{
    [Fact]
    public void ApplicationIdentity_ShouldHaveValidProperties()
    {
        // Arrange
        var type = typeof(SharedKernel.Entities.ApplicationIdentity);
        
        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new FluentAssertions.Execution.AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(SharedKernel.Entities.ApplicationIdentity.Username) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(SharedKernel.Entities.ApplicationIdentity.Password) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(SharedKernel.Entities.ApplicationIdentity.RefreshToken) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(SharedKernel.Entities.ApplicationIdentity.RefreshTokenExpiryTime) && x.PropertyType == typeof(DateTime?));
        }
    }
}