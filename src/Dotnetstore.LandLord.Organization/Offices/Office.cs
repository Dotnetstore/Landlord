namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class Office
{
    public OfficeId Id { get; init; }
    
    public string Name { get; init; } = string.Empty;

    public string? CorporateId { get; init; }
}

internal record struct OfficeId(Guid Value);