using Shared.Settings;
using System.Net.Http.Headers;

namespace WebAPI.Configurations
{
    public static class FactoryConfiguration
    {
        public static void AddFactoryService(this IServiceCollection services)
        {
            services.AddHttpClient("HttpFactoryViaCEP", config =>
            {
                if (SettingsWebAPI.UrisExternals?.ViaCep?.BaseUri != null)
                {
                    config.BaseAddress = new Uri(SettingsWebAPI.UrisExternals.ViaCep.BaseUri);
                    config.DefaultRequestHeaders.Accept.Clear();
                    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
            });
        }
    }
}
