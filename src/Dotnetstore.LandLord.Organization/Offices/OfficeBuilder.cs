using Ardalis.GuardClauses;
using Dotnetstore.LandLord.SharedKernel.Services;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class OfficeBuilder :
    ICreateOfficeId,
    ICreateOfficeName,
    ICreateCorporateId,
    IBuild
{
    private OfficeId _id;
    private string _name = null!;
    private string? _corporateId;

    private OfficeBuilder()
    {
    }

    internal static ICreateOfficeId Create()
    {
        return new OfficeBuilder();
    }
    
    ICreateOfficeName ICreateOfficeId.WithId(OfficeId id)
    {
        var officeId = Guard.Against.Default(id.Value, nameof(id));
        _id = new OfficeId(officeId);
        return this;
    }
    
    ICreateCorporateId ICreateOfficeName.WithName(string name)
    {
        var officeName = Guard.Against.NullOrEmpty(name, nameof(name));
        officeName = Guard.Against.StringTooLong(officeName, DataSchemeConstants.MaxCompanyNameLength, nameof(officeName));
        _name = officeName;
        return this;
    }
    
    IBuild ICreateCorporateId.WithCorporateId(string? corporateId)
    {
        if (corporateId is null) return this;
        var id = Guard.Against.StringTooLong(corporateId, DataSchemeConstants.MaxSocialSecurityNumberLength, nameof(corporateId));
        var success = Organisationsnummer.Organisationsnummer.Valid(id);
        if (!success)
            throw new ArgumentException($"'{nameof(corporateId)}' is not a valid corporate id.", nameof(corporateId));
        _corporateId = id;
        return this;
    }
    
    Office IBuild.Build()
    {
        return new Office
        {
            CorporateId = _corporateId,
            Id = _id,
            Name = _name
        };
    }
}

internal interface ICreateOfficeId
{
    ICreateOfficeName WithId(OfficeId id);
}

internal interface ICreateOfficeName
{
    ICreateCorporateId WithName(string name);
}

internal interface ICreateCorporateId
{
    IBuild WithCorporateId(string? corporateId = null);
}

internal interface IBuild
{
    Office Build();
}