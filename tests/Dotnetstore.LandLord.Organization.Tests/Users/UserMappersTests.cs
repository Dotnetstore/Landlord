using Dotnetstore.LandLord.Organization.Offices;
using Xunit;
using Dotnetstore.LandLord.Organization.Users;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Dotnetstore.LandLord.Organization.Tests.Users;

public class UserMappersTests
{
    [Fact]
    public void ToUserResponse_ShouldMapUserToUserResponse()
    {
        // Arrange
        var userId = new UserId(Guid.NewGuid());
        var user = new User
        {
            Id = userId,
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A",
            SocialSecurityNumber = "123-45-6789",
            IsMale = true,
            OfficeId = new OfficeId(Guid.NewGuid()),
            Username = "test@test.com",
            Password = "password"
        };
        const string token = "sample_token";
        const string refreshToken = "sample_refresh_token";

        // Act
        var response = user.ToLoginUserResponse(token, refreshToken);

        // Assert
        using (new AssertionScope())
        {
            response.Id.Should().Be(userId.Value);
            response.OfficeId.Should().Be(user.OfficeId.Value);
            response.LastName.Should().Be(user.LastName);
            response.FirstName.Should().Be(user.FirstName);
            response.MiddleName.Should().Be(user.MiddleName);
            response.SocialSecurityNumber.Should().Be(user.SocialSecurityNumber);
            response.IsMale.Should().Be(user.IsMale);
            response.Token.Should().Be(token);
            response.RefreshToken.Should().Be(refreshToken);
        }
    }
}