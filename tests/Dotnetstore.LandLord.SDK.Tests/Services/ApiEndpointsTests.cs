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
            ApiEndpoints.V1.Organization.Office.GetById.Should().Be("/api/v1/organization/offices/{id:guid}");
            ApiEndpoints.V1.Organization.Office.Create.Should().Be("/api/v1/organization/offices");
            ApiEndpoints.V1.Organization.Office.Update.Should().Be("/api/v1/organization/offices/{id:guid}");
            ApiEndpoints.V1.Organization.Office.Delete.Should().Be("/api/v1/organization/offices/{id:guid}");
        }
    }
    
    [Fact]
    public void ApiEndpoints_User_ShouldHaveValidEndpoints()
    {
        // Assert
        using (new AssertionScope())
        {
            ApiEndpoints.V1.Organization.User.Login.Should().Be("/api/v1/organization/users/login");
        }
    }
}