using Dotnetstore.LandLord.SDK.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Services;

public class ApiEndpointsTests
{
    [Fact]
    public void ApiEndpoints_Office_ShouldHaveValidEndpoints()
    {
        // Assert
        using (new AssertionScope())
        {
            ApiEndpoints.V1.Organization.Office.GetAll.Should().Be("/api/v1/organization/offices");
        }
    }
}