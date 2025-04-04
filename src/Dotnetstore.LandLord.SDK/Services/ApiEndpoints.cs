namespace Dotnetstore.LandLord.SDK.Services;

public static class ApiEndpoints
{
    private static string BaseUrl => "/api";
    
    public static class V1
    {
        private static string V1BaseUrl => $"{BaseUrl}/v1";
        
        public static class Organization
        {
            private static string OrganizationBaseUrl => $"{V1BaseUrl}/organization";
            
            public static class Office
            {
                private static string OfficeBaseUrl => $"{OrganizationBaseUrl}/offices";
                
                public static string GetAll => OfficeBaseUrl;
            }
        }
    }
}