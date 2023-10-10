using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;

using Crypt = BCrypt.Net.BCrypt;

namespace GameDatabase.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var authInfo = await _authRepository.GetAuthInformation(email, password);

            if (authInfo == null)
            {
                return null;
            }

            if (!Crypt.Verify(password, authInfo.PasswordHash))
            {
                return null;
            }


            var jwtToken = _tokenService.IssueTokenForAuthentication(authInfo);

            return jwtToken;
        }

        public async Task<Authentication> SignupUser(string email, string password, string username)
        {
            string salt = Crypt.GenerateSalt();
            string hashedPassword = Crypt.HashPassword(password, salt);

            return await _authRepository.CreateUserAuthInformation(email, hashedPassword, username);
        }
    }
}
