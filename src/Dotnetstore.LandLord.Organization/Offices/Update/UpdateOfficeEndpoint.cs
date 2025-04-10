using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Offices.Update;

internal sealed class UpdateOfficeEndpoint(IOfficeService officeService) : Endpoint<UpdateOfficeRequest>
{
    public override void Configure()
    {
        Put(ApiEndpoints.V1.Organization.Office.Update);
        Description(x =>
            x.WithDescription("Create new office")
                .AutoTagOverride("Offices"));
        Summary(s =>
        {
            s.Summary = "Create new office";
            s.Description = "Create new office";
            s.Response<IEnumerable<OfficeResponse>>();
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateOfficeRequest req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var result = await officeService.UpdateAsync(id, req, ct);
        
        if (!result.IsSuccess)
        {
            AddError(string.Join(", ", result.Errors));
            await SendErrorsAsync(statusCode: StatusCodes.Status400BadRequest, cancellation: ct);
            return;
        }

        await SendNoContentAsync(cancellation: ct);
    }
}