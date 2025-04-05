namespace Dotnetstore.LandLord.SDK.Requests.Organization;

// public record struct LoginUserRequest(
//     Guid OfficeId,
//     string Username,
//     string Password);

public sealed class LoginUserRequest()
{
    public Guid OfficeId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}