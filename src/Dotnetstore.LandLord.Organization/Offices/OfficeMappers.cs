using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Offices;

internal static class OfficeMappers
{
    internal static OfficeResponse ToOfficeResponse(this Office office)
    {
        return new OfficeResponse(
            office.Id.Value,
            office.Name,
            office.CorporateId);
    }
}