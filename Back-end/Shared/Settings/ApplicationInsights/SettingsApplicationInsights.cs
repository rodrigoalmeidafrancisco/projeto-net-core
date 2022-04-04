namespace Shared.Settings.ApplicationInsights
{
    public class SettingsApplicationInsights
    {
        public SettingsApplicationInsights()
        {
            InstrumentationKey = string.Empty;
        }

        public string InstrumentationKey { get; set; }
    }
}
