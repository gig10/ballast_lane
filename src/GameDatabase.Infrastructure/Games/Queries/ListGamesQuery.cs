using GameDatabase.Infrastructure.BaseQueries;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.Games.Queries
{
    internal class ListGamesQuery : BaseQuery<DbGame>
    {
        private const string query = @"select top 30 * from games";
        public ListGamesQuery()
        {

        }
        public override SqlCommand Build(SqlConnection connection)
        {
            var cmd = new SqlCommand(query, connection);

            return cmd;
        }
    }
}
