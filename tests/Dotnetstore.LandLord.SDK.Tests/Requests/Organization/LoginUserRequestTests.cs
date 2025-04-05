using Dotnetstore.LandLord.SDK.Requests.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Requests.Organization;

public class LoginUserRequestTests
{
    [Fact]
    public void LoginUserRequest_Should_ContainProperties()
    {
        // Arrange
        var officeId = Guid.NewGuid();
        const string username = "testuser";
        const string password = "testpassword";
    
        // Act
        var request = new LoginUserRequest
        {
            OfficeId = officeId,
            Username = username,
            Password = password
        };
    
        // Assert
        using (new AssertionScope())
        {
            request.OfficeId.Should().Be(officeId);
            request.Username.Should().Be(username);
            request.Password.Should().Be(password);
        }
    }
}