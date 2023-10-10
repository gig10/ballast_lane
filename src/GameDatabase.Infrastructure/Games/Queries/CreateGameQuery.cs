using GameDatabase.Infrastructure.BaseQueries;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;

namespace GameDatabase.Infrastructure.Games.Queries
{
    internal class CreateGameQuery : BaseQuery<DbGame>
    {
        private const string query = @"insert into games ([title], [description], [imageurl]) values (@title, @description, @imageurl); SELECT SCOPE_IDENTITY();";
        public CreateGameQuery(DbGame game) : base(game)
        {

        }

        public override SqlCommand Build(SqlConnection connection)
        {
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@title", Entity.Title);
            cmd.Parameters.AddWithValue("@description", Entity.Description);
            cmd.Parameters.AddWithValue("@imageurl", Entity.ImageUrl);

            return cmd;
        }
    }
}
