using Dotnetstore.LandLord.Organization.Data;
using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.Organization.Services;
using Dotnetstore.LandLord.SharedKernel.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnetstore.LandLord.Organization.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddOrganization(
        this WebApplicationBuilder builder,
        string connectionName)
    {
        builder.AddNpgsqlDbContext<OrganizationDataContext>(connectionName);
        
        builder.Services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IOfficeRepository, OfficeRepository>()
            .AddScoped<IOfficeService, OfficeService>()
            .EnsureDbDeleted<OrganizationDataContext>()
            .EnsureDbCreated<OrganizationDataContext>();

        return builder;
    }
}