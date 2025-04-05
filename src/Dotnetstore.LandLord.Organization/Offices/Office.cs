using Dotnetstore.LandLord.Organization.Users;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class Office
{
    public OfficeId Id { get; init; }
    
    public string Name { get; init; } = string.Empty;

    public string? CorporateId { get; init; }
    
    public ICollection<User> Users { get; init; } = new List<User>();
}

internal record struct OfficeId(Guid Value);