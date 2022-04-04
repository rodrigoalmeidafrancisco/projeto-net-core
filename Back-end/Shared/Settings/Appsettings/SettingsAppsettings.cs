namespace Shared.Settings.Appsettings
{
    public class SettingsAppsettings
    {
        public SettingsAppsettings()
        {
            Environment = string.Empty;
            Proxy = new ConfigProxy();
            Release = string.Empty;
            WebRootPath = string.Empty;
        }

        public SettingsAppsettings(string environment, ConfigProxy proxy, string release, string webRootPath)
        {
            Environment = environment;
            Proxy = proxy;
            Release = release;
            WebRootPath = webRootPath;
        }

        public string Environment { get; set; }
        public ConfigProxy Proxy { get; set; }
        public string Release { get; set; }
        public string WebRootPath { get; set; }
    }
}
