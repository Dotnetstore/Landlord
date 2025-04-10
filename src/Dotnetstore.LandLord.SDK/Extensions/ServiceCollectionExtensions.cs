using Dotnetstore.LandLord.SDK.Clients.Organization;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.LandLord.SDK.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSdk(
        this IServiceCollection services,
        string baseUrl)
    {
        services.AddHttpClient("LandLord", client =>
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        })
        .AddStandardResilienceHandler();

        services
            .AddScoped<IOfficeClient, OfficeClient>();
        
        return services;
    }
}