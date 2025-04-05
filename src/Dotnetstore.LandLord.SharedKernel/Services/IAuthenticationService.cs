namespace Dotnetstore.LandLord.SharedKernel.Services;

public interface IAuthenticationService
{
    string GetAccessToken(
        string surname,
        string givenName,
        string email,
        Guid id);
    
    string GetRefreshToken();
}