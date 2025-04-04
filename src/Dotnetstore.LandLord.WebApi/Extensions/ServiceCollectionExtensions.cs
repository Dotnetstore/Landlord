using Dotnetstore.LandLord.Organization.Extensions;
using Dotnetstore.LandLord.ServiceDefaults;
using Dotnetstore.LandLord.SharedKernel.Extensions;

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
    }
}