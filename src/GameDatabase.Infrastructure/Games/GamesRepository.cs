using AutoMapper;

using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;
using GameDatabase.Infrastructure.DbEntities;
using GameDatabase.Infrastructure.Games.Queries;

using Microsoft.Extensions.Options;

namespace GameDatabase.Infrastructure.Games
{
    public class GamesRepository : BaseRepository<Game, DbGame>, IGamesRepository
    {
        public GamesRepository(IOptions<DatabaseOptions> options, IMapper mapper) : base(options, mapper)
        {
        }

        public async Task<Game> Create(Game game)
        {
            var dbGame = MapFromEntity(game);
            var query = new CreateGameQuery(dbGame);

            int id = await ExecuteScalarAsync(query);
            dbGame.Id = id;
            return MapFromDbEntity(dbGame);
        }

        public Task<List<Game>> GetAll()
        {
            var query = new ListGamesQuery();
            return ExecuteListAsync(query);            
        }

        public Task<Game> GetGameById(int id)
        {
            var query = new FindGameQuery(id);
            return ExecuteSelectSingleAsync(query);
        }
    }
}
