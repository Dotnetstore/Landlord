using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Offices.Delete;

internal sealed class DeleteOfficeEndpoint(IOfficeService officeService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete(ApiEndpoints.V1.Organization.Office.Delete);
        Description(x =>
            x.WithDescription("Delete office")
                .AutoTagOverride("Offices"));
        Summary(s =>
        {
            s.Summary = "Delete office";
            s.Description = "Delete office";
            s.Response<IEnumerable<OfficeResponse>>();
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var result = await officeService.DeleteAsync(id, ct);
        
        if (!result.IsSuccess)
        {
            AddError(string.Join(", ", result.Errors));
            await SendErrorsAsync(statusCode: StatusCodes.Status400BadRequest, cancellation: ct);
            return;
        }
        
        await SendNoContentAsync(cancellation: ct);
    }
}