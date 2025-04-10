using Ardalis.Result;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Offices;

internal interface IOfficeService
{
    ValueTask<IEnumerable<OfficeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    
    ValueTask<Result<OfficeResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    ValueTask<Result<OfficeResponse>> CreateAsync(CreateOfficeRequest req, CancellationToken cancellationToken = default);
    
    ValueTask<Result<OfficeResponse>> UpdateAsync(Guid id, UpdateOfficeRequest req, CancellationToken cancellationToken = default);
    
    ValueTask<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}