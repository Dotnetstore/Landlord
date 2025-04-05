using Dotnetstore.LandLord.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Users;

public class UserIdTests
{
    [Fact]
    public void UserId_ShouldCreateWithValidGuid()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var userId = new UserId(guid);

        // Assert
        userId.Value.Should().Be(guid);
    }

    [Fact]
    public void UserId_ShouldBeEqual_WhenGuidsAreSame()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userId1 = new UserId(guid);
        var userId2 = new UserId(guid);

        // Act & Assert
        userId1.Should().Be(userId2);
    }

    [Fact]
    public void UserId_ShouldNotBeEqual_WhenGuidsAreDifferent()
    {
        // Arrange
        var userId1 = new UserId(Guid.NewGuid());
        var userId2 = new UserId(Guid.NewGuid());

        // Act & Assert
        userId1.Should().NotBe(userId2);
    }
}