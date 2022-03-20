using ElmahCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Caching.Memory;
using Shared.Settings;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Dependencys;

namespace WebAPI.Configurations.Base
{
    public static class BaseConfiguration
    {
        public static void InitializerConfigurationService(this WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            //Configura para utilizar o IIS, quando publicar.
            builder.WebHost.UseIISIntegration();

            //Configura para utilizar os logs no console.
            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

            //Obtendo as configurações da API "appsettings.json (Release) / appsettings.Development.json (Debug)"
            SettingsWebAPI.Init(builder.Configuration, builder.Services);
            
            if (SettingsWebAPI.BaseWebAPI != null)
            {
                SettingsWebAPI.BaseWebAPI.WebRootPath = builder.Environment.WebRootPath;
            }

            //Configurando o proxy caso necessário
            if (SettingsWebAPI.BaseWebAPI?.Proxy != null && SettingsWebAPI.BaseWebAPI.Proxy.UtilizarProxy)
            {
                HttpClient.DefaultProxy = new WebProxy(new Uri($"{SettingsWebAPI.BaseWebAPI.Proxy.Url}:{SettingsWebAPI.BaseWebAPI.Proxy.Porta}"), true, SettingsWebAPI.BaseWebAPI.Proxy.ByPassArray)
                {
                    UseDefaultCredentials = false,
                    Credentials = CredentialCache.DefaultCredentials
                };
            }

            //Configura os parâmetros do System.Text.Json para o Retorno da API   
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(x => x.AddPolicy("AllowAll", y => { y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            //Permite fazer a validação do ComponentModel.Annotations
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //Configura a utilização do Application Insights
            builder.Services.AddApplicationInsightsTelemetry(SettingsWebAPI.ApplicationInsights.InstrumentationKey);

            //Comprime o Json no Retorno da API, diminuindo o seu tamanho
            builder.Services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            //Configuração para que o IMemoryCache seja distribuido entre os servidores no balance. 
            builder.Services.AddDistributedMemoryCache();

            //Configurção das Dependências do projeto
            builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
            RegisterDependencies.Start(builder.Services);
        }
        
        public static void InitializerConfigurationAPP(this WebApplication app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                //app.UseElmahExceptionPage(); //Utiliza a página de erro do Elmah
                app.UseDeveloperExceptionPage();
            }

            app.AddSwaggerAPP();

            //Padrão de rotas do MVC
            app.UseRouting();
            app.MapControllers();

            //Força a API responder apenas em HTTPS
            app.UseHttpsRedirection();

            //Poder realizar chamadas localhost em tempo de desenvolvimento
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication(); // Autenticação
            app.UseAuthorization(); // Roles

            //Informa a utilização do Elmah
            app.UseElmah();
        }

    }
}
