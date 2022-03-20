using ExtensionCore;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Shared.Helpers;
using Shared.Settings;

namespace WebAPI.Configurations
{
    public static class ApplicationInsightsConfiguration
    {
        public static void AddTelemetryInitializer(this IServiceCollection services)
        {
            services.AddSingleton<ITelemetryInitializer, TelemetryInitializer>();
        }

        public static void AddTelemetryStart(this WebApplication app)
        {
            HelperLog.Start(app.Services.GetRequiredService<TelemetryClient>());
        }

        public class TelemetryInitializer : ITelemetryInitializer
        {
            public void Initialize(ITelemetry telemetry)
            {
                if (telemetry.Context != null)
                {
                    if (telemetry.Context.Cloud != null && telemetry.Context.Cloud.RoleName.IsNullOrEmptyOrWhiteSpace())
                    {
                        telemetry.Context.Cloud.RoleName = $"Portal RH API ({SettingsWebAPI.BaseWebAPI?.Environment})";
                    }

                    telemetry.Context.GlobalProperties["Ambiente API"] = SettingsWebAPI.BaseWebAPI?.Environment;
                    telemetry.Context.GlobalProperties["Versão API"] = SettingsWebAPI.BaseWebAPI?.Release;
                }

                if (telemetry is RequestTelemetry requestTelemetry)
                {
                    int.TryParse(requestTelemetry.ResponseCode, out int cod);

                    if (cod == 400)
                    {
                        //Retorno da requisição configurado como Ok e não como falha.
                        requestTelemetry.Success = true;
                        requestTelemetry.Context.GlobalProperties[$"Overriden{cod}s"] = "true";
                    }
                }
            }
        }

    }
}
