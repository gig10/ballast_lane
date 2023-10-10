using GameDatabase.API.Extensions;
using GameDatabase.Core.Entities;
using GameDatabase.Core.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace GameDatabase.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwt;
        public TokenService(IOptions<JwtOptions> options)
        {
            _jwt = options.Value;
        }

        public string IssueTokenForAuthentication(Authentication auth)
        {
            if (auth == null)
            {
                throw new ArgumentNullException(nameof(auth));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", auth.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, auth.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, auth.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.Now.AddYears(1),
                Issuer = _jwt.Issuer,
                Audience = _jwt.Audience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
