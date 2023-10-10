using AutoMapper;

using GameDatabase.API.GamesEndpoints.ApiModels;
using GameDatabase.Core.Entities;

namespace GameDatabase.API.GamesEndpoints
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<GameCreateRequest, Game>();
            CreateMap<Game, GameResponse>();
        }
    }
}
