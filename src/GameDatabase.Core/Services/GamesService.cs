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

        public async Task<Game> GetGame()
        {
            return await _repository.GetFirst();
        }
    }
}
