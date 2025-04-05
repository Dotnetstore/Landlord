using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.SharedKernel.Entities;

namespace Dotnetstore.LandLord.Organization.Users;

internal sealed class User : ApplicationIdentity
{
    public UserId Id { get; init; }

    public OfficeId OfficeId { get; init; }
    
    public Office Office { get; init; } = null!;
}

internal record struct UserId(Guid Value);