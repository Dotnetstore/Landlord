using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SharedKernel.Services;
using FastEndpoints;
using FluentValidation;

namespace Dotnetstore.LandLord.Organization.Users.Login;

internal sealed class LoginUserRequestValidation : Validator<LoginUserRequest>
{
    public LoginUserRequestValidation()
    {
        RuleFor(x => x.OfficeId)
            .NotEmpty()
            .WithMessage("OfficeId is required");
        
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(DataSchemeConstants.MaxUsernameLength)
            .WithMessage($"Wrong username or password.")
            .EmailAddress()
            .WithMessage("Wrong username or password.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}