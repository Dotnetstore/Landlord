using Dotnetstore.LandLord.SDK.Responses.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Responses.Organization;

public class OfficeResponseTests
{
    [Fact]
    public void OfficeResponse_Should_ContainProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string name = "Test Office";
        const string corporateId = "CORP123";

        // Act
        var officeResponse = new OfficeResponse(id, name, corporateId);

        // Assert
        using (new AssertionScope())
        {
            officeResponse.Id.Should().Be(id);
            officeResponse.Name.Should().Be(name);
            officeResponse.CorporateId.Should().Be(corporateId);
        }
    }
}