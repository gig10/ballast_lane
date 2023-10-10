using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.Auth.Queries
{
    internal class GetSingleAuth : SingleSelectQuery<DBAuthentication>
    {
        private const string query = @"Select [Id], [Email], [Password_Hash], [UserName] from [Users] Where [Email] = @email";
        private readonly string _email;

        public GetSingleAuth(string email):base()
        {
            _email = email;
        }

        public override SqlCommand Build(SqlConnection connection)
        {
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@email", _email);
            return cmd;
        }
    }
}
