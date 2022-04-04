namespace Shared.Settings.Authentication
{
    public class SettingsAuthentication
    {
        public SettingsAuthentication()
        {

        }

        public SettingsAuthentication(string audience, string authority, bool requireHttpsMetadata, bool saveToken, bool validateAudience, bool validateIssuer)
        {
            Audience = audience;
            Authority = authority;
            RequireHttpsMetadata = requireHttpsMetadata;
            SaveToken = saveToken;
            ValidateAudience = validateAudience;
            ValidateIssuer = validateIssuer;
        }

        public string Audience { get; set; }
        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public bool SaveToken { get; set; }
        public string SecretToken => "b4fd91b1-89b3-49c2-b088-52684409b8cc";
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
    }
}
