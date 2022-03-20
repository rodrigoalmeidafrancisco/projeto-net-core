namespace Shared.Settings.UrisExternals
{
    public class ConfigViaCep
    {
        public ConfigViaCep()
        {
            BaseUri = string.Empty;
            GetCEP = string.Empty;
        }

        public string? BaseUri { get; set; }
        public string? GetCEP { get; set; }
    }
}
