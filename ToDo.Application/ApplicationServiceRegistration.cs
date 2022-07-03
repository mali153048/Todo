using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Contracts.Services;
using ToDo.Application.Services;

namespace ToDo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
            }, Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
