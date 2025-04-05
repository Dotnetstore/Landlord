using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Dotnetstore.LandLord.SharedKernel.Services;

public sealed class AuthenticationService(IConfiguration configuration) : IAuthenticationService
{
    string IAuthenticationService.GetAccessToken(
        string surname,
        string givenName,
        string email,
        Guid id)
    {
        var key = configuration.GetValue<string>("AuthenticationService:TokenKey"); 
        ArgumentException.ThrowIfNullOrWhiteSpace("Key should not be empty.", nameof(key));
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Surname, surname),
            new(ClaimTypes.GivenName, givenName),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Sid, id.ToString()),
        };
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = configuration.GetValue<string>("AuthenticationService:Issuer"),
            Audience = configuration.GetValue<string>("AuthenticationService:Audience"),
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = signingCredentials
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    string IAuthenticationService.GetRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}