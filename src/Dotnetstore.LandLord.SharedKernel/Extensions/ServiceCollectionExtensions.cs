using Dotnetstore.LandLord.SharedKernel.Enums;
using Dotnetstore.LandLord.SharedKernel.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.LandLord.SharedKernel.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSharedKernel(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<IAuthenticationService, AuthenticationService>();

        return builder;
    }
    
    public static IServiceCollection AddDbContext<T>(
        this IServiceCollection services, 
        DatabaseOption databaseOption,
        string connectionString) where T : DbContext
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services.AddDbContext<T>(options =>
        {
            switch (databaseOption)
            {
                case DatabaseOption.MSSQL:
                    options.UseSqlServer(connectionString);
                    break;
                case DatabaseOption.PostgreSQL:
                    options.UseNpgsql(connectionString);
                    break;
                case DatabaseOption.SQLite:
                    options.UseSqlite(connectionString);
                    break;
                case DatabaseOption.InMemory:
                    options.UseInMemoryDatabase(connectionString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(databaseOption), databaseOption, null);
            }
        });
        
        return services;
    }
    
    public static IServiceCollection EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.EnsureCreated();
        
        return services;
    }
    
    public static IServiceCollection EnsureDbDeleted<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.EnsureDeleted();
        
        return services;
    }
    
    public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
    {
        var descriptor = services.SingleOrDefault(d => typeof(DbContextOptions<T>) == d.ServiceType);
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }
    }
    
    public static IServiceCollection EnsureDbMigrated<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.Migrate();
        
        return services;
    }
}