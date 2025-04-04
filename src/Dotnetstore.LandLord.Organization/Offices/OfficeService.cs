using Dotnetstore.LandLord.Organization.Services;
using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class OfficeService(IUnitOfWork unitOfWork) : IOfficeService
{
    async ValueTask<IEnumerable<OfficeResponse>> IOfficeService.GetAllAsync(CancellationToken cancellationToken)
    {
        var offices = await unitOfWork
            .Offices
            .GetAllAsync(cancellationToken);
        
        return offices.Select(x => new OfficeResponse(x.Id.Value, x.Name, x.CorporateId)).ToList();
    }
}