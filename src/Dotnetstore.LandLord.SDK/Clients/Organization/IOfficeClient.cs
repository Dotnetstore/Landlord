using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.SDK.Clients.Organization;

public interface IOfficeClient
{
    ValueTask<(IEnumerable<OfficeResponse> OfficeResponse, HttpResponseMessage httpResponseMessage)> GetAllAsync(CancellationToken ct);
    ValueTask<(OfficeResponse OfficeResponse, HttpResponseMessage httpResponseMessage)> GetByIdAsync(Guid id, CancellationToken ct);
    ValueTask<(OfficeResponse OfficeResponse, HttpResponseMessage httpResponseMessage)> CreateAsync(CreateOfficeRequest createOfficeRequest, CancellationToken ct);
    ValueTask<(bool IsSuccess, HttpResponseMessage httpResponseMessage)> UpdateAsync(Guid id, UpdateOfficeRequest updateOfficeRequest, CancellationToken ct);
    ValueTask<(bool IsSuccess, HttpResponseMessage httpResponseMessage)> DeleteAsync(Guid id, CancellationToken ct);
}