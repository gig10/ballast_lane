using AutoMapper;

using GameDatabase.API.GamesEndpoints.ApiModels;
using GameDatabase.Core.Entities;
using GameDatabase.Core.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDatabase.API.GameEndpoints
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;
        private readonly IMapper _mapper;

        public GamesController(IGamesService gamesService, IMapper mapper)
        {
            _gamesService = gamesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var games = await _gamesService.ListGames();
            return Ok(_mapper.Map<List<GameResponse>>(games));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGame([FromRoute] int id)
        {
            var game = await _gamesService.GetGameById(id);
            return Ok(_mapper.Map<GameResponse>(game));
        }


        [HttpPost]
        public async Task<ActionResult> CreateGame([FromBody] GameCreateRequest gameCreateRequest)
        {
            var newgame = _mapper.Map<Game>(gameCreateRequest);
            var dbGame = await _gamesService.CreateGame(newgame);
            return Ok(_mapper.Map<GameResponse>(dbGame));
        }
    }
}
