namespace Dotnetstore.LandLord.SharedKernel.Entities;

public abstract class Person
{
    public string LastName { get; init; } = string.Empty;
    
    public string FirstName { get; init; } = string.Empty;
    
    public string? MiddleName { get; init; }

    public string? SocialSecurityNumber { get; init; }

    public bool IsMale { get; init; }
}