using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Users;

internal static class UserMappers
{
    internal static LoginUserResponse ToLoginUserResponse(
        this User user,
        string token,
        string refreshToken)
    {
        return new LoginUserResponse(
            user.Id.Value,
            user.OfficeId.Value,
            user.LastName,
            user.FirstName,
            user.MiddleName,
            user.SocialSecurityNumber,
            user.IsMale,
            token,
            refreshToken);
    }
}