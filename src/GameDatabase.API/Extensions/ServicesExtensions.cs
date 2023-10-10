using GameDatabase.API.Services;
using GameDatabase.Core.Interfaces;
using GameDatabase.Core.Services;
using GameDatabase.Infrastructure;

namespace GameDatabase.API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>((opt) => opt.ConnectionString = configuration.GetConnectionString("dbconnection"));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGamesService, GamesService>();
            return services;
        }
    }
}
