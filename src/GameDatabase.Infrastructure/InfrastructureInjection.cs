using GameDatabase.Core.Interfaces;
using GameDatabase.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace GameDatabase.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
