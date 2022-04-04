using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebAPI.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoNetCore.API", Version = "v1" });

                //Configura o Swagger para que possa fazer requisição com a API, incluíndo um Bearer Token para as chamadas direto na tela.
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Cabeçalho de autorização JWT usando o esquema Bearer. \r\n\r\nDigite 'Bearer'[espaço] e, em seguida, seu token na entrada de texto abaixo.  \r\n\r\nExemplo: \"Bearer 12345abcdef\""
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });

                //Permite que apareça o Summary do método da controller
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddSwaggerAPP(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.DefaultModelsExpandDepth(-1); ;
                x.SwaggerEndpoint("v1/swagger.json", "ProjetoNetCore.API");
                x.DocumentTitle = "ProjetoNetCore.API";
            });
        }

    }
}
