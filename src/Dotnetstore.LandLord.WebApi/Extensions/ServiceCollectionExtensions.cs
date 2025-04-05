using System.Text;
using Dotnetstore.LandLord.Organization.Extensions;
using Dotnetstore.LandLord.ServiceDefaults;
using Dotnetstore.LandLord.SharedKernel.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Dotnetstore.LandLord.WebApi.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddWebApi(
        this WebApplicationBuilder builder,
        string connectionName)
    {
        builder
            .AddServiceDefaults()
            .AddSharedKernel()
            .AddOrganization(connectionName);

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("AuthenticationService:Issuer"),
                    ValidAudience = builder.Configuration.GetValue<string>("AuthenticationService:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration.GetValue<string>("AuthenticationService:TokenKey")!))
                };
            });
    }
}