namespace Shared.Settings.Appsettings
{
    public class ConfigProxy
    {
        public ConfigProxy()
        {
            ByPass = string.Empty;
            Porta = 0;
            Url = string.Empty;
            UseProxy = false;
        }

        public ConfigProxy(string byPass, int porta, string url, bool useProxy)
        {
            ByPass = byPass;
            Porta = porta;
            Url = url;
            UseProxy = useProxy;
        }

        public string ByPass { get; set; }
        public string[] ByPassArray => ByPass.Split('|');
        public int Porta { get; set; }
        public string Url { get; set; }
        public bool UseProxy { get; set; }
    }
}
