using Ardalis.Result;
using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.Organization.Services;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.AspNetCore.Identity;

namespace Dotnetstore.LandLord.Organization.Users;

internal sealed class UserService(
    IUnitOfWork unitOfWork,
    IAuthenticationService authenticationService) : IUserService
{
    async ValueTask<Result<LoginUserResponse>> IUserService.LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var userToCheck = await unitOfWork.Users.GetByOfficeAndUsernameAsync(
            new OfficeId(request.OfficeId),
            request.Username, 
            cancellationToken);
        
        if (userToCheck is null)
            return Result<LoginUserResponse>.NotFound("Wrong username or password");
        
        var passwordCheckResult = new PasswordHasher<User>().VerifyHashedPassword(userToCheck, userToCheck.Password, request.Password);
        
        if (passwordCheckResult == PasswordVerificationResult.Failed)
            return Result<LoginUserResponse>.NotFound("Wrong username or password");
        
        var refreshToken = authenticationService.GetRefreshToken();
        userToCheck.RefreshToken = refreshToken;
        userToCheck.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(9);
        
        unitOfWork.Users.Update(userToCheck);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        var token = authenticationService.GetAccessToken(
            userToCheck.LastName, 
            userToCheck.FirstName, 
            userToCheck.Username, 
            userToCheck.Id.Value);
        
        return userToCheck.ToLoginUserResponse(token, refreshToken);
    }
}