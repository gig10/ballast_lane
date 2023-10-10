using GameDatabase.API.Extensions;
using GameDatabase.Core.Services;

using Microsoft.Extensions.Options;

namespace GameDatabase.API.Services
{
    public class TokenService : ITokenService
    {
        public TokenService(IOptions<JwtOptions> options)
        {

        }

        public string IssueTokenForUser()
        {
            return "asd123";
        }
    }
}
