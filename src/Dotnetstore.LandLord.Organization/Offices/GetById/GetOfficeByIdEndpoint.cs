using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Offices.GetById;

internal sealed class GetOfficeByIdEndpoint(IOfficeService officeService) : EndpointWithoutRequest<OfficeResponse>
{
    public override void Configure()
    {
        Get(ApiEndpoints.V1.Organization.Office.GetById);
        Description(x =>
            x.WithDescription("Get office by id")
                .AutoTagOverride("Offices"));
        Summary(s =>
        {
            s.Summary = "Get office by id";
            s.Description = "Get office by id";
            s.Response<OfficeResponse>();
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var officeId = Route<Guid>("id");
        var result = await officeService.GetByIdAsync(officeId, ct);

        if (!result.IsSuccess)
        {
            await SendNotFoundAsync(cancellation: ct);
            return;
        }

        await SendAsync(result.Value, statusCode: StatusCodes.Status200OK, cancellation: ct);
    }
}