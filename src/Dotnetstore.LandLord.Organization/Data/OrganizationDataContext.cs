using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.Organization.Users;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.Organization.Data;

internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : DbContext(options)
{
    public DbSet<Office> Offices { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationDataContext).Assembly);
    }
}