using GameDatabase.Core.Entities;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.Auth.Queries
{
    internal class CreateUserAuthQuery : BaseQuery<DBAuthentication>
    {
        const string query = @"Insert into [Users] ([Email], [Password_Hash], [UserName]) Values (@email, @password, @username)";
        public CreateUserAuthQuery(DBAuthentication auth) : base(auth)
        {
        }

        public override SqlCommand Build(SqlConnection connection)
        {
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@email", Entity.Email);
            cmd.Parameters.AddWithValue("@password", Entity.PasswordHash);
            cmd.Parameters.AddWithValue("@username", Entity.UserName);

            return cmd;
        }
    }
}
