using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Offices;

internal interface IOfficeService
{
    ValueTask<IEnumerable<OfficeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}