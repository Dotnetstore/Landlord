using Xunit;
using FluentValidation.TestHelper;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.Organization.Users.Login;
using Dotnetstore.LandLord.SharedKernel.Services;

namespace Dotnetstore.LandLord.Organization.Tests.Users.Login;

public class LoginUserRequestValidationTests
{
    private readonly LoginUserRequestValidation _validator = new();

    [Fact]
    public void Should_Have_Error_When_OfficeId_Is_Empty()
    {
        var model = new LoginUserRequest { OfficeId = Guid.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.OfficeId)
              .WithErrorMessage("OfficeId is required");
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Empty()
    {
        var model = new LoginUserRequest { Username = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username)
              .WithErrorMessage("Username is required");
    }

    [Fact]
    public void Should_Have_Error_When_Username_Exceeds_MaxLength()
    {
        var model = new LoginUserRequest { Username = new string('a', DataSchemeConstants.MaxUsernameLength + 1) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username)
              .WithErrorMessage("Wrong username or password.");
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Not_Valid_Email()
    {
        var model = new LoginUserRequest { Username = "invalid-email" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username)
              .WithErrorMessage("Wrong username or password.");
    }

    [Fact]
    public void Should_Have_Error_When_Password_Is_Empty()
    {
        var model = new LoginUserRequest { Password = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password)
              .WithErrorMessage("Password is required");
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var model = new LoginUserRequest
        {
            OfficeId = Guid.NewGuid(),
            Username = "user@example.com",
            Password = "ValidPassword123"
        };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}