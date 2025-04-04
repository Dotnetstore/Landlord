using Dotnetstore.LandLord.Organization.Offices;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Offices;

public class OfficeTests
{
    [Fact]
    public void Office_Should_ContainProperties()
    {
        // Arrange
        var type = typeof(Office);
        
        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(Office.Id) && x.PropertyType == typeof(OfficeId));
            properties.Should().ContainSingle(x => x.Name == nameof(Office.Name) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(Office.CorporateId) && x.PropertyType == typeof(string));
        }
    }
}