using GameDatabase.Core.Interfaces;
using GameDatabase.Core.Services;

using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GameDatabase.Infrastructure.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString;
        public AuthRepository(IConfiguration configs)
        {
            _connectionString = configs.GetConnectionString("dbconnection");
        }
        public async Task<Authentication> CreateUserAuthInformation(string email, string password_hash, string username)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqlCommand(AuthQueries.CreateUserAuth, connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password_hash);
            command.Parameters.AddWithValue("@username", username);

            int id = await command.ExecuteNonQueryAsync();

            return await Task.FromResult(new Authentication()
            {
                Email = email,
                UserName = username,
                Id = id,
            });
        }

        public async Task<Authentication> GetAuthInformation(string email, string plaintext_password)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqlCommand(AuthQueries.GetUserAuth, connection);

            command.Parameters.AddWithValue("@email", email);

            var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                var authResp = new Authentication()
                {
                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    PasswordHash = (string)reader["Password_Hash"],
                    UserName = (string)reader["userName"]
                };

                return authResp;
            }
            else
            {
                return null;
            }

        }
    }
}

