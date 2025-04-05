using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnetstore.LandLord.Organization.Users;

internal sealed class UserConfiguration : ApplicationIdentityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserId, Guid>(
            v => v.Value,
            v => new UserId(v));
        
        var officeIdConverter = new ValueConverter<OfficeId, Guid>(
            v => v.Value,
            v => new OfficeId(v));
        
        builder
            .HasIndex(x => x.Id)
            .IsUnique();
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder
            .Property(x => x.OfficeId)
            .HasConversion(officeIdConverter)
            .IsRequired();

        builder
            .HasOne(x => x.Office)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.OfficeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}