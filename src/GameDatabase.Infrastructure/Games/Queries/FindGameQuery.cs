using GameDatabase.Infrastructure.BaseQueries;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.Games.Queries
{
    internal class FindGameQuery : BaseQuery<DbGame>
    {
        private readonly int _id;
        private const string query = @"Select top 1 * from games where id = @id";

        public FindGameQuery(int id)
        {
            _id = id;
        }
        public override SqlCommand Build(SqlConnection connection)
        {
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", _id);

            return cmd;
        }
    }
}
