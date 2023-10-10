using GameDatabase.API.Extensions;

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace UnitTests
{
    public static class HelperMethods
    {
        public static string GenerateTestToken(JwtOptions options, int id, string user, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: options.Issuer,
                audience: options.Audience,
                claims: new[]
                {
                    new Claim("Id", id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                },
                expires: DateTime.UtcNow.AddDays(1));

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }

        public static bool ValidateToken(string token, int id, string user, string email, JwtOptions options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters(options);

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            bool valid = true;

            valid &= jwtToken.Claims.First(c => c.Type == "Id")?.Value == id.ToString();
            valid &= jwtToken.Claims.First(c => c.Type == "sub").Value == user;
            valid &= jwtToken.Claims.First(c => c.Type == "email").Value == email;

            return valid;
        }

        private static TokenValidationParameters GetValidationParameters(JwtOptions options)
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = options.Issuer,
                ValidAudience = options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key)) // The same key as the one that generate the token
            };
        }
    }
}
