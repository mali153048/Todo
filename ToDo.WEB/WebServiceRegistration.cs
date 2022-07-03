using Microsoft.AspNetCore.Authentication.Cookies;
using ToDo.Infrastructure.ConfigurationModels;

namespace ToDo.WEB
{
    public static class WebServiceRegistration
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DBSettings>(configuration.GetSection("AppSettings:DBSettings"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Error/Forbidden/";
                options.LoginPath = "/auth/login/";
            });

            return services;

        }
    }
}
