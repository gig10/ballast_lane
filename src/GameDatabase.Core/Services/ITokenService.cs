using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Services
{
    public interface ITokenService
    {
        string IssueTokenForAuthentication(Authentication auth);
    }
}
