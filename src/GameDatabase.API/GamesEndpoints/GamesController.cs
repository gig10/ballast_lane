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

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var game = await _gamesService.GetGame(); 
            return await Task.FromResult(Ok(game));
        }

    }
}
