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
                public static string GetById => $"{OfficeBaseUrl}/{{id:guid}}";
                public static string Create => OfficeBaseUrl;
                public static string Update => $"{OfficeBaseUrl}/{{id:guid}}";
                public static string Delete => $"{OfficeBaseUrl}/{{id:guid}}";
            }
            
            public static class User
            {
                private static string UserBaseUrl => $"{OrganizationBaseUrl}/users";
                
                public static string Login => $"{UserBaseUrl}/login";
            }
        }
    }
}