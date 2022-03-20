using Data.Local.Contexts;
using Domain.Contracts.Handlers;
using Domain.Handlers;
using Microsoft.EntityFrameworkCore;
using Shared.Settings;

namespace WebAPI.Dependencys
{
    public static class RegisterDependencies
    {
        //services.AddDbContext -> já faz a mesma função do AddScoped.
        //services.AddSingleton -> Provem uma intancia do objeto para aplicação toda, sempre ativa.
        //services.AddScoped -> Busca sempre da memoria caso exista, se não cria.
        //services.AddTransient -> Cada requisição cria uma nova instância.

        public static void Start(IServiceCollection services)
        {
            Handlers(services);
            DataLocal(services);
            DataExternal(services);
        }

        private static void Handlers(IServiceCollection services)
        {
            services.AddScoped<IAccountHandler, AccountHandler>();
        }

        private static void DataLocal(IServiceCollection services)
        {
            //Contexto Default
            services.AddDbContext<ContextDefault>(options => options.UseSqlServer(SettingsWebAPI.ConnectionStrings.Default)
               .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            );


        }

        private static void DataExternal(IServiceCollection services)
        {

        }

    }
}
