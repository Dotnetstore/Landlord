using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SharedKernel.Services;
using FastEndpoints;
using FluentValidation;

namespace Dotnetstore.LandLord.Organization.Offices.Create;

internal sealed class CreateOfficeRequestValidation : Validator<CreateOfficeRequest>
{
    public CreateOfficeRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(DataSchemeConstants.MaxCompanyNameLength)
            .WithMessage($"Name must be less or equal than {DataSchemeConstants.MaxCompanyNameLength} characters.");
        
        RuleFor(x => x.CorporateId)
            .Custom((s, context) =>
            {
                if (string.IsNullOrEmpty(s))
                    return;
                var success = Organisationsnummer.Organisationsnummer.Valid(s);
                if (!success)
                    context.AddFailure("CorporateId is not a valid Swedish corporate id.");
            })
            .MaximumLength(DataSchemeConstants.MaxSocialSecurityNumberLength)
            .WithMessage($"CorporateId must be less or equal than {DataSchemeConstants.MaxSocialSecurityNumberLength} characters.");
    }
}