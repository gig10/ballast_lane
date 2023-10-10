using AutoMapper;

using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;
using GameDatabase.Infrastructure.DbEntities;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GameDatabase.Infrastructure.Games
{
    public class GamesRepository : BaseRepository<Game, DbGame>, IGamesRepository
    {
        private readonly string _connectionString;
        public GamesRepository(IOptions<DatabaseOptions> options, IMapper mapper) : base(options, mapper)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public async Task<Game> Create(Game game)
        {
            var query = new SingleGame();
            var res = await ExecuteSelectSingleAsync(query);
            return await Task.FromResult(new Game());
        }

        public async Task<Game> GetFirst()
        {
            var query = new SingleGame();
            var result = await ExecuteSelectSingleAsync(query);
            return result;
        }
    }

    public class SingleGame : SingleSelectQuery<DbGame>
    {
        public SingleGame()
        {

        }

        public override SqlCommand Build(SqlConnection connection)
        {
            return new SqlCommand("Select top 1 * from games", connection);
        }
    }
}
