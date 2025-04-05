using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.LandLord.SharedKernel.Entities;

public abstract class ApplicationIdentityConfiguration<T> : PersonConfiguration<T> where T : ApplicationIdentity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(x => x.Username)
            .HasMaxLength(DataSchemeConstants.MaxUsernameLength)
            .IsRequired()
            .IsUnicode(false);

        builder
            .Property(x => x.Password)
            .HasMaxLength(DataSchemeConstants.MaxPasswordLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.RefreshToken)
            .HasMaxLength(DataSchemeConstants.MaxRefreshTokenLength)
            .IsRequired(false)
            .IsUnicode(false);
        
        builder
            .Property(x => x.RefreshTokenExpiryTime)
            .IsRequired(false);
    }
}