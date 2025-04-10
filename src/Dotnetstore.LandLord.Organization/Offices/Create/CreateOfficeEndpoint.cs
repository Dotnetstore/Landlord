using Dotnetstore.LandLord.Organization.Offices.GetById;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Offices.Create;

internal sealed class CreateOfficeEndpoint(IOfficeService officeService) : Endpoint<CreateOfficeRequest, OfficeResponse>
{
    public override void Configure()
    {
        Post(ApiEndpoints.V1.Organization.Office.Create);
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

    public override async Task HandleAsync(CreateOfficeRequest req, CancellationToken ct)
    {
        var result = await officeService.CreateAsync(req, ct);

        if (!result.IsSuccess)
        {
            AddError(string.Join(", ", result.Errors));
            await SendErrorsAsync(statusCode: StatusCodes.Status400BadRequest, cancellation: ct);
            return;
        }
        
        await SendCreatedAtAsync<GetOfficeByIdEndpoint>(new {id = result.Value.Id}, result.Value, cancellation: ct);
    }
}