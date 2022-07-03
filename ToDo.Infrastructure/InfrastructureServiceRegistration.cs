using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Contracts.Repositories;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}