namespace WebAPI.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static void AddAuthenticationService(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = "";
                options.RequireHttpsMetadata = true;
                options.Audience = "";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("NetCorePolicy", policy =>
                {
                    policy.RequireClaim("scope", "NetCore.API");
                });
            });
        }

    }
}
