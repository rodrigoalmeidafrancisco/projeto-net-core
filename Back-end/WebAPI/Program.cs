using WebAPI.Configurations;
using WebAPI.Configurations.Base;

var builder = WebApplication.CreateBuilder(args);
builder.InitializerConfigurationService(); //Faz as configurações do WebApplicationBuilder da API
builder.Services.AddTelemetryDependency(); //Configura a Dependência do Telemetry ApplicationInsights
builder.Services.AddAuthenticationService(); //Configura a autenticação da API
builder.Services.AddFactoryService(); //Cria as Factory para as chamadas HTTP
builder.Services.AddSwaggerService(); //Configura o Swagger

var app = builder.Build();
app.InitializerConfigurationAPP(); //Faz as configurações do WebApplication da API
app.AddTelemetryStart(); //Inicia os logs do Telemetry ApplicationInsights

await app.RunAsync();
