using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Offices.GetAll;

internal sealed class GetAllOfficesEndpoint(IOfficeService officeService) : EndpointWithoutRequest<IEnumerable<OfficeResponse>>
{
    public override void Configure()
    {
        Get(ApiEndpoints.V1.Organization.Office.GetAll);
        Summary(s =>
        {
            s.Summary = "Get all offices";
            s.Description = "Get all offices";
            s.Response<IEnumerable<OfficeResponse>>(StatusCodes.Status200OK);
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var offices = await officeService.GetAllAsync(ct);
        await SendAsync(offices, statusCode: StatusCodes.Status200OK, cancellation: ct);
    }
}