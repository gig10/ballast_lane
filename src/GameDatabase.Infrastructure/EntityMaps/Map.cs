using AutoMapper;

using GameDatabase.Core.Entities;
using GameDatabase.Infrastructure.DbEntities;

namespace GameDatabase.Infrastructure.EntityMaps
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<DBAuthentication, Authentication>().ReverseMap();
            CreateMap<DbGame, Game>().ReverseMap();
        }
    }
}
