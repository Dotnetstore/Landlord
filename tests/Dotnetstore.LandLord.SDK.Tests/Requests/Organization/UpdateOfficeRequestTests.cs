using Dotnetstore.LandLord.SDK.Requests.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Requests.Organization;

public class UpdateOfficeRequestTests
{
    [Fact]
    public void UpdateOfficeRequest_ShouldHaveCorrectProperties()
    {
        // Arrange
        var type = typeof(UpdateOfficeRequest);

        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(UpdateOfficeRequest.Name) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(UpdateOfficeRequest.CorporateId) && x.PropertyType == typeof(string));
        }
    }
}