using Dotnetstore.LandLord.Organization.Offices;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.Organization.Data;

internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : DbContext(options)
{
    public DbSet<Office> Offices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationDataContext).Assembly);
    }
}