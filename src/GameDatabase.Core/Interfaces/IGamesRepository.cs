using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Interfaces
{
    public interface IGamesRepository
    {
        Task<Game> Create(Game game);
        Task<Game> GetGameById(int id);

        Task<List<Game>> GetAll();
    }
}
