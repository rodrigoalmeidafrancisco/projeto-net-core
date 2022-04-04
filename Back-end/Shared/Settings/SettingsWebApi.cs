using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings.ApplicationInsights;
using Shared.Settings.Appsettings;
using Shared.Settings.Authentication;
using Shared.Settings.ConnectionStrings;

namespace Shared.Settings
{
    public static class SettingsWebApi
    {
        private static IServiceCollection _serviceCollection;

        public static void Init(IConfiguration configuration, IServiceCollection services)
        {
            _serviceCollection = services;

            ApplicationInsights = new SettingsApplicationInsights();
            configuration.GetSection("ApplicationInsights").Bind(ApplicationInsights);

            Appsettings = new SettingsAppsettings();
            configuration.GetSection("Appsettings").Bind(Appsettings);

            Authentication = new SettingsAuthentication();
            configuration.GetSection("Authentication").Bind(Authentication);
            
            ConnectionStrings = new SettingsConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(ConnectionStrings);
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
        public static SettingsAppsettings Appsettings { get; set; }
        public static SettingsAuthentication Authentication { get; set; }
        public static SettingsConnectionStrings ConnectionStrings { get; set; }

    }
}
