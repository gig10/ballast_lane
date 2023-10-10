using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Services
{
    public interface IGamesService
    {
        Task<Game> GetGameById(int id);
        Task<List<Game>> ListGames();

        Task<Game> CreateGame(Game game);
    }
}
