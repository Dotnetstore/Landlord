namespace Dotnetstore.LandLord.WebUI.Extensions;

internal static class MiddlewareExtensions
{
    internal static void AddWebUI(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app
                .UseExceptionHandler("/Error")
                .UseHsts();
        }

        app
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization();

        app
            .MapStaticAssets();
        
        app
            .MapRazorPages()
            .WithStaticAssets();
    }
}