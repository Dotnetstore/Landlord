using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.LandLord.SharedKernel.Entities;

public abstract class PersonConfiguration<T> : IEntityTypeConfiguration<T> where T : Person
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .Property(x => x.LastName)
            .HasMaxLength(DataSchemeConstants.MaxPersonNameLength)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.FirstName)
            .HasMaxLength(DataSchemeConstants.MaxPersonNameLength)
            .IsRequired()
            .IsUnicode();

        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(DataSchemeConstants.MaxPersonNameLength)
            .IsRequired(false)
            .IsUnicode();

        builder
            .Property(x => x.SocialSecurityNumber)
            .HasMaxLength(DataSchemeConstants.MaxSocialSecurityNumberLength)
            .IsRequired(false)
            .IsUnicode(false);

        builder
            .Property(x => x.IsMale)
            .IsRequired();
    }
}