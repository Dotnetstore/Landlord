namespace Dotnetstore.LandLord.SDK.Responses.Organization;

public record struct OfficeResponse(
    Guid Id,
    string Name,
    string? CorporateId);