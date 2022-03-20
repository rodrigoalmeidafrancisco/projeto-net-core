using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings.ApplicationInsights;
using Shared.Settings.AuthenticationWebAPI;
using Shared.Settings.BaseWebAPI;
using Shared.Settings.ConnectionStrings;
using Shared.Settings.UrisExternals;

namespace Shared.Settings
{
    public static class SettingsWebAPI
    {
        private static IServiceCollection? _serviceCollection;

        public static void Init(IConfiguration configuration, IServiceCollection services)
        {
            _serviceCollection = services;

            ApplicationInsights = new SettingsApplicationInsights();
            configuration.GetSection("ApplicationInsights").Bind(ApplicationInsights);

            AuthenticationWebAPI = new SettingsAuthenticationWebAPI();
            configuration.GetSection("AuthenticationWebAPI").Bind(AuthenticationWebAPI);

            BaseWebAPI = new SettingsBaseWebAPI();
            configuration.GetSection("BaseWebAPI").Bind(BaseWebAPI);

            ConnectionStrings = new SettingsConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(ConnectionStrings);

            UrisExternals = new SettingsUrisExternals();
            configuration.GetSection("UrisExternals").Bind(ConnectionStrings);
        }

        public static T GetService<T>()
        {
            ServiceProvider servicesProvider = _serviceCollection.BuildServiceProvider();

            using (var scope = servicesProvider.CreateScope())
            {
                return scope.ServiceProvider.GetService<T>();
            }
        }

        public static SettingsApplicationInsights ApplicationInsights { get; set; }
        public static SettingsAuthenticationWebAPI AuthenticationWebAPI { get; set; }
        public static SettingsBaseWebAPI BaseWebAPI { get; set; }
        public static SettingsConnectionStrings ConnectionStrings { get; set; }
        public static SettingsUrisExternals UrisExternals { get; set; }
    }
}
