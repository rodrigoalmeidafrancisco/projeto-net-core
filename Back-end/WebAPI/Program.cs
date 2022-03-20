using WebAPI.Configurations;
using WebAPI.Configurations.Base;

var builder = WebApplication.CreateBuilder(args);
builder.InitializerConfigurationService(); //Faz as configurações do WebApplicationBuilder da API
builder.Services.AddTelemetryInitializer(); //Inicia o Telemetry do ApplicationInsights
builder.Services.AddAuthenticationService(); //Configura a autenticação da API
builder.Services.AddFactoryService(); //Cria as Factory para as chamadas HTTP
builder.Services.AddSwaggerService(); //Configura o Swagger
builder.Services.AddElmah(); //Configrua o Elmah

var app = builder.Build();
app.InitializerConfigurationAPP(); //Faz as configurações do WebApplication da API
app.AddTelemetryStart();
app.Run();