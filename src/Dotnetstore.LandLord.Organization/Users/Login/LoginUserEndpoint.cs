using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.LandLord.Organization.Users.Login;

internal sealed class LoginUserEndpoint(IUserService userService) : Endpoint<LoginUserRequest, LoginUserResponse>
{
    public override void Configure()
    {
        Get(ApiEndpoints.V1.Organization.User.Login);
        Description(x =>
            x.WithDescription("Login user")
                .AutoTagOverride("Users"));
        Summary(s =>
        {
            s.Summary = "Login user";
            s.Description = "Login user.";
            s.Response<LoginUserResponse>();
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginUserRequest req, CancellationToken ct)
    {
        var result = await userService.LoginAsync(req, ct).ConfigureAwait(false);
        
        if(!result.IsSuccess)
        {
            AddError(string.Join(", ", result.Errors));
            await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
            return;
        }
        
        await SendAsync(result.Value, statusCode: StatusCodes.Status200OK, cancellation: ct);
    }
}