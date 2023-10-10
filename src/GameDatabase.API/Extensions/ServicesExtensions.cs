using GameDatabase.Core.Interfaces;
using GameDatabase.Core.Services;

namespace GameDatabase.API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
