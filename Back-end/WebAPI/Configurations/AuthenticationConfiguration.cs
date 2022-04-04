using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Settings;
using System.Text;

namespace WebAPI.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static void AddAuthenticationService(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(SettingsWebApi.Authentication.SecretToken);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Authority = SettingsWebApi.Authentication.Authority;
                x.RequireHttpsMetadata = SettingsWebApi.Authentication.RequireHttpsMetadata;
                x.Audience = SettingsWebApi.Authentication.Audience;
                x.SaveToken = SettingsWebApi.Authentication.SaveToken;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = SettingsWebApi.Authentication.ValidateIssuer,
                    ValidateAudience = SettingsWebApi.Authentication.ValidateAudience,
                    ValidIssuer = SettingsWebApi.Authentication.Authority,
                    ValidAudience = SettingsWebApi.Authentication.Audience
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PolicyScope", policy => { policy.RequireClaim("scope", new[] { "ScopeProjetoNetCore" }); });
            });

        }
    }
}
