using System.Net.Http.Headers;

namespace WebAPI.Configurations
{
    public static class FactoryConfiguration
    {
        public static void AddFactoryService(this IServiceCollection services)
        {
            services.AddHttpClient("HttpFactoryA", config =>
            {
                config.BaseAddress = new Uri("{informeAqui}");
                config.DefaultRequestHeaders.Accept.Clear();
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            //services.AddHttpClient("HttpFactoryB", config =>
            //{
            //    config.BaseAddress = new Uri("{informeAqui}");
            //    config.DefaultRequestHeaders.Accept.Clear();
            //    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //}).AddHttpMessageHandler<RequestTokenHeaderHandler>();
            
        }
    }
}
