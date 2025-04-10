using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        var converter = new ValueConverter<OfficeId, Guid>(
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
            .Property(x => x.Name)
            .HasMaxLength(DataSchemeConstants.MaxCompanyNameLength)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.CorporateId)
            .HasMaxLength(DataSchemeConstants.MaxSocialSecurityNumberLength)
            .IsRequired(false)
            .IsUnicode(false);

        builder
            .HasData(OfficeBuilder.Create()
                .WithId(new OfficeId(Guid.CreateVersion7()))
                .WithName("Dotnetstore")
                .WithCorporateId()
                .Build());
    }
}