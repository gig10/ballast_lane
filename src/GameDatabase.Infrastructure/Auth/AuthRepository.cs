using AutoMapper;

using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;
using GameDatabase.Infrastructure.Auth.Queries;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Extensions.Options;

namespace GameDatabase.Infrastructure.Auth
{
    public class AuthRepository : BaseRepository<Authentication, DBAuthentication>, IAuthRepository
    {
        public AuthRepository(IOptions<DatabaseOptions> options, IMapper mapper) : base(options, mapper)
        {

        }
        public async Task<Authentication> CreateUserAuthInformation(string email, string password_hash, string username)
        {
            var auth = new DBAuthentication()
            {
                Email = email,
                PasswordHash = password_hash,
                UserName = username
            };

            var query = new CreateUserAuthQuery(auth);

            int id = await ExecuteNonQueryAsync(query);
            auth.Id = id;

            return MapFromDbEntity(auth);            
        }

        public async Task<Authentication> GetAuthInformation(string email, string plaintext_password)
        {
            var auth = await ExecuteSelectSingleAsync(new GetSingleAuth(email));
            return auth;
        }
    }
}

