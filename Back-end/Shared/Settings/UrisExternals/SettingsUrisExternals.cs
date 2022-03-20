namespace Shared.Settings.UrisExternals
{
    public class SettingsUrisExternals
    {
        public SettingsUrisExternals()
        {
            ViaCep = new ConfigViaCep();
        }

        public ConfigViaCep? ViaCep { get; set; }
    }
}
