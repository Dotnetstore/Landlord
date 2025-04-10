namespace Dotnetstore.LandLord.SDK.Requests.Organization;

public sealed class UpdateOfficeRequest
{
    public string Name { get; init; } = string.Empty;

    public string? CorporateId { get; init; }
}