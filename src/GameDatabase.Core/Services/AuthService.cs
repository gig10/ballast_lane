using GameDatabase.Core.Interfaces;

using Crypt = BCrypt.Net.BCrypt;

namespace GameDatabase.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task AuthenticateUser(string email, string password)
        {
            await _authRepository.GetAuthInformation(email, password);
        }

        public async Task<Authentication> SignupUser(string email, string password, string username)
        {
            string salt = Crypt.GenerateSalt();
            string hashedPassword = Crypt.HashPassword(password, salt);

            return await _authRepository.CreateUserAuthInformation(email, hashedPassword, username);
        }
    }
}
