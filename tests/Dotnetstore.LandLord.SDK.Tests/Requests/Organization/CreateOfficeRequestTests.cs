using Dotnetstore.LandLord.SDK.Requests.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Requests.Organization;

public class CreateOfficeRequestTests
{
    [Fact]
    public void CreateOfficeRequest_ShouldHaveCorrectProperties()
    {
        // Arrange
        var type = typeof(CreateOfficeRequest);

        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(CreateOfficeRequest.Name) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(CreateOfficeRequest.CorporateId) && x.PropertyType == typeof(string));
        }
    }
}