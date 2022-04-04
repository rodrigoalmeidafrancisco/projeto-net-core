using ExtensionCore;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Shared.Helpers;
using Shared.Settings;

namespace WebAPI.Configurations
{
    public static class ApplicationInsightsConfiguration
    {
        public static void AddTelemetryDependency(this IServiceCollection services)
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
                        telemetry.Context.Cloud.RoleName = $"ProjetoNetCore.API ({SettingsWebApi.Appsettings.Environment})";
                    }

                    telemetry.Context.GlobalProperties["Environment.API"] = SettingsWebApi.Appsettings.Environment;
                    telemetry.Context.GlobalProperties["Release.API"] = SettingsWebApi.Appsettings.Release;
                }

                //if (telemetry is RequestTelemetry requestTelemetry)
                //{
                //    int.TryParse(requestTelemetry.ResponseCode, out int cod);

                //    if (cod >= 400 && cod < 500)
                //    {
                //        //Retorno da requisição configurado como Ok e não como falha.
                //        requestTelemetry.Success = true;
                //        requestTelemetry.Context.GlobalProperties[$"Overriden{cod}s"] = "true";
                //    }
                //}
            }
        }

    }
}
