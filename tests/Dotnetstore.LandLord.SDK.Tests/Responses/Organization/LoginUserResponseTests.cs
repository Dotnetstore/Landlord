using Dotnetstore.LandLord.SDK.Responses.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Responses.Organization;

public class LoginUserResponseTests
{
    [Fact]
    public void LoginUserResponse_ShouldHaveCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var officeId = Guid.NewGuid();
        const string lastName = "Doe";
        const string firstName = "John";
        const string middleName = "A";
        const string socialSecurityNumber = "123-45-6789";
        const bool isMale = true;
        const string token = "sample_token";
        const string refreshToken = "sample_refresh_token";

        // Act
        var response = new LoginUserResponse(
            id,
            officeId,
            lastName,
            firstName,
            middleName,
            socialSecurityNumber,
            isMale,
            token,
            refreshToken);

        // Assert
        using (new AssertionScope())
        {
            response.Id.Should().Be(id);
            response.OfficeId.Should().Be(officeId);
            response.LastName.Should().Be(lastName);
            response.FirstName.Should().Be(firstName);
            response.MiddleName.Should().Be(middleName);
            response.SocialSecurityNumber.Should().Be(socialSecurityNumber);
            response.IsMale.Should().Be(isMale);
            response.Token.Should().Be(token);
            response.RefreshToken.Should().Be(refreshToken);
        }
    }
}