using Dotnetstore.LandLord.SDK.Extensions;
using Dotnetstore.LandLord.ServiceDefaults;
using Dotnetstore.LandLord.WebUI.Filters;

namespace Dotnetstore.LandLord.WebUI.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddWebUI(this WebApplicationBuilder builder)
    {
        builder
            .AddServiceDefaults();
        
        builder.Services
            .AddSdk("https+http://apiService")
            .AddRazorPages(options =>
            {
                // options.Conventions.AllowAnonymousToPage("/Account/Login");
                options.Conventions.AddFolderApplicationModelConvention("/", model =>
                {
                    model.Filters.Add(new ValidateModelStatePageFilter());
                });
            });

        builder.Services
            .Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });
    }
}    