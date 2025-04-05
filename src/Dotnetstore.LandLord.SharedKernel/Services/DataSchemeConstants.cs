namespace Dotnetstore.LandLord.SharedKernel.Services;

public sealed class DataSchemeConstants
{
    public static int MaxCompanyNameLength => 100;
    public static int MaxPersonNameLength => 25;
    public static int MaxSocialSecurityNumberLength => 11;
    public static int MaxUsernameLength => 255;
    public static int MaxPasswordLength => 500;
    public static int MaxRefreshTokenLength => 500;
}