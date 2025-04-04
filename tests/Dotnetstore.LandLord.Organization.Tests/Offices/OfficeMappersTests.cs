using Xunit;
using FluentAssertions;
using Dotnetstore.LandLord.Organization.Offices;
using FluentAssertions.Execution;

namespace Dotnetstore.LandLord.Organization.Tests.Offices;

public class OfficeMappersTests
{
    [Fact]
    public void ToOfficeResponse_ShouldMapOfficeToOfficeResponse()
    {
        // Arrange
        var officeId = new OfficeId(Guid.NewGuid());
        var office = new Office
        {
            Id = officeId,
            Name = "Test Office",
            CorporateId = "Corp123"
        };

        // Act
        var response = office.ToOfficeResponse();

        // Assert
        using (new AssertionScope())
        {
            response.Id.Should().Be(officeId.Value);
            response.Name.Should().Be("Test Office");
            response.CorporateId.Should().Be("Corp123");
        }
    }

    [Fact]
    public void ToOfficeResponse_ShouldHandleNullCorporateId()
    {
        // Arrange
        var officeId = new OfficeId(Guid.NewGuid());
        var office = new Office
        {
            Id = officeId,
            Name = "Test Office",
            CorporateId = null
        };

        // Act
        var response = office.ToOfficeResponse();

        // Assert
        using (new AssertionScope())
        {
            response.Id.Should().Be(officeId.Value);
            response.Name.Should().Be("Test Office");
            response.CorporateId.Should().BeNull();
        }
    }
}