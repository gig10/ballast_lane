using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateUser(string email, string password);
        Task<Authentication> SignupUser(string email, string password, string username);
    }
}
