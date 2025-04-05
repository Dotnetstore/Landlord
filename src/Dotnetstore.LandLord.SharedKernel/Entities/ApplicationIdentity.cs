namespace Dotnetstore.LandLord.SharedKernel.Entities;

public abstract class ApplicationIdentity : Person
{
    public string Username { get; init; } = string.Empty;
    
    public string Password { get; init; } = string.Empty;

    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }
}