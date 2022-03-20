using Microsoft.ApplicationInsights;

namespace Shared.Helpers
{
    public static class HelperLog
    {
        private static TelemetryClient? _telemetryClient { get; set; }

        public static void Start(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public static void Exception(Exception exception, Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null)
        {
            _telemetryClient?.TrackException(exception, properties, metrics);

            if (properties == null)
            {
                properties = new Dictionary<string, string>() { { "StackTrace", $"{exception?.StackTrace}" } };
            }

            TrackEvent($"Log Exception (Message): {exception?.Message}", properties, metrics);
        }

        public static void TrackEvent(string frase, Dictionary<string, string> propriedadesLog = null, Dictionary<string, double> metricasLog = null)
        {
            _telemetryClient?.TrackEvent($"{frase}", propriedadesLog, metricasLog);
        }
    }
}
