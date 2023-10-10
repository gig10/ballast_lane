using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace GameDatabase.API.Extensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtOptions>();
            var symmetricKeyData = Encoding.UTF8.GetBytes(jwt.Key);

            services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme =
                 options.DefaultChallengeScheme =
                 options.DefaultChallengeScheme =
                 JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer = jwt.Issuer,
                     ValidAudience = jwt.Audience,
                     IssuerSigningKey = new SymmetricSecurityKey(symmetricKeyData),
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = false,
                     ValidateIssuerSigningKey = true
                 };
             });


            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JWT));
            services.AddAuthorization();
            return services;
        }
    }
}
