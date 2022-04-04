using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Settings;

namespace WebAPI.Configurations
{
    public static class ElmahConfiguration
    {
        public static void AddElmah(this IServiceCollection services)
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.Path = @"elmah";
                options.ApplicationName = "ProjetoNetCoreAPI";
                options.OnPermissionCheck = context => SettingsWebApi.Appsettings.Environment.Equals("PROD", StringComparison.OrdinalIgnoreCase) == false;
                options.ConnectionString = SettingsWebApi.ConnectionStrings.Default;
                options.Notifiers.Add(new ElmahNotification());
                options.Filters.Add(new ElmahErrorFilter());
            });
        }

        public class ElmahErrorFilter : ExceptionFilterAttribute, IErrorFilter
        {
            public void OnErrorModuleFiltering(object sender, ExceptionFilterEventArgs args)
            {
                if (args.Exception.GetBaseException() is FileNotFoundException)
                {
                    args.Dismiss();
                }

                if (args.Context is HttpContext httpContext)
                {
                    if (httpContext.Response.StatusCode == 404)
                    {
                        args.Dismiss();
                    }
                }
            }
        }

        public class ElmahNotification : IErrorNotifier
        {
            public string Name => "";

            public void Notify(Error error)
            {
               
            }
        }

    }
}
