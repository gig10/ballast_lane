using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;

namespace GameDatabase.Core.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _repository;

        public GamesService(IGamesRepository repository)
        {
            _repository = repository;
        }

        public Task<Game> CreateGame(Game game)
        {
            return _repository.Create(game);
        }

        public Task<Game> GetGameById(int id)
        {
            return _repository.GetGameById(id);
        }

        public Task<List<Game>> ListGames()
        {
            return _repository.GetAll();
        }
    }
}
