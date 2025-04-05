namespace Dotnetstore.LandLord.SDK.Responses.Organization;

public record struct LoginUserResponse(
    Guid Id,
    Guid OfficeId,
    string LastName,
    string FirstName,
    string? MiddleName,
    string? SocialSecurityNumber,
    bool IsMale,
    string Token,
    string RefreshToken);