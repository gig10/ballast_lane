using GameDatabase.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Core.Interfaces
{
    public interface IGamesRepository
    {
        Task<Game> Create(Game game);
        Task<Game> GetFirst();
    }
}
