using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<Authentication> GetAuthInformation(string email, string plaintext_password);
        Task<Authentication> CreateUserAuthInformation(string email, string password_hash, string username);
    }
}
