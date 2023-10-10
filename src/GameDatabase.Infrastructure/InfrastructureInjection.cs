using GameDatabase.Core.Interfaces;
using GameDatabase.Infrastructure.Auth;
using GameDatabase.Infrastructure.Games;

using Microsoft.Extensions.DependencyInjection;

namespace GameDatabase.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddAutoMapper(typeof(AuthRepository));
            return services;
        }
    }
}
