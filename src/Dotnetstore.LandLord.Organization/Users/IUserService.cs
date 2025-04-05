using Ardalis.Result;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Users;

internal interface IUserService
{
    ValueTask<Result<LoginUserResponse>> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken = default);
}