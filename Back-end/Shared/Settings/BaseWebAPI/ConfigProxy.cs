namespace Shared.Settings.BaseWebAPI
{
    public class ConfigProxy
    {
        public ConfigProxy()
        {
            UtilizarProxy = false;
            ByPass = string.Empty;
            Porta = 0;
            Url = string.Empty;
        }

        public bool UtilizarProxy { get; set; }
        public string ByPass { get; set; }
        public string[] ByPassArray => ByPass.Split('|');
        public int Porta { get; set; }
        public string Url { get; set; }
    }
}
