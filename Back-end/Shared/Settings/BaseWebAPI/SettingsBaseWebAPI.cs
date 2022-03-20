namespace Shared.Settings.BaseWebAPI
{
    public class SettingsBaseWebAPI
    {
        public SettingsBaseWebAPI()
        {
            Environment = string.Empty;
            Proxy = new ConfigProxy();
            Release = string.Empty;
            SystemName = string.Empty;
            WebRootPath = string.Empty;
        }

        public string? Environment { get; set; }
        public ConfigProxy? Proxy { get; set; }
        public string? Release { get; set; }
        public string? SystemName { get; set; }
        public string? WebRootPath { get; set; }
    }
}
