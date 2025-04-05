using System.Text;
using Dotnetstore.LandLord.Organization.Extensions;
using Dotnetstore.LandLord.ServiceDefaults;
using Dotnetstore.LandLord.SharedKernel.Extensions;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
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
            .AddAuthenticationJwtBearer(s =>
                s.SigningKey = builder.Configuration.GetValue<string>("AuthenticationService:TokenKey"))
            .AddAuthorization()
            .AddFastEndpoints()
            .SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "Dotnetstore Landlord API";
                    s.Version = "v1";
                    s.Description = "Dotnetstore Landlord API Documentation";
                };
            });
    }
}