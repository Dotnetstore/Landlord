using Xunit;
using Dotnetstore.LandLord.Organization.Offices;
using FluentAssertions;

namespace Dotnetstore.LandLord.Organization.Tests.Offices;

public class OfficeIdTests
{
    [Fact]
    public void OfficeId_ShouldCreateWithValidGuid()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var officeId = new OfficeId(guid);

        // Assert
        officeId.Value.Should().Be(guid);
    }

    [Fact]
    public void OfficeId_ShouldBeEqual_WhenGuidsAreSame()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var officeId1 = new OfficeId(guid);
        var officeId2 = new OfficeId(guid);

        // Act & Assert
        officeId1.Should().Be(officeId2);
    }

    [Fact]
    public void OfficeId_ShouldNotBeEqual_WhenGuidsAreDifferent()
    {
        // Arrange
        var officeId1 = new OfficeId(Guid.NewGuid());
        var officeId2 = new OfficeId(Guid.NewGuid());

        // Act & Assert
        officeId1.Should().NotBe(officeId2);
    }
}