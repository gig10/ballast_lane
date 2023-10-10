using GameDatabase.Core.Entities;

namespace GameDatabase.Core.Services
{
    public interface IGamesService
    {
        Task<Game> GetGame();
    }
}
