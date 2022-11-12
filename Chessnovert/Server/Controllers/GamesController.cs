using Chessnovert.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chessnovert.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService gameService;

        public GamesController(GameService gameService)
        {
            this.gameService = gameService;
        }
        //GET: api/OpenChallenges
        [HttpGet("OpenChallenges")]
        public IEnumerable<string> OpenChallenges()
        {
            return gameService.Games.Where(n => n.Value < 2).Select(n => n.Key);
        }

        // GET: api/{id}
        [HttpGet("{id}")]
        public IActionResult GetGame(string id)
        {
            int players = 0;
            bool exists = gameService.Games.TryGetValue(id,out players);
            if(exists) return Ok(players);
            else return NotFound();
        }

        // POST api/<GamesController>
        [HttpPost]
        public IActionResult Post([FromBody] Guid gameId)
        {
            var existingGameId = gameService.Games.Where(g => g.Key == gameId.ToString()).Select(g => g.Key);
            if(existingGameId.IsNullOrEmpty())
            {
                gameService.Games.Add(gameId.ToString(), 0);
            }
            else
            {
                return Conflict();
            }
            return CreatedAtAction(nameof(GetGame), new { id = gameId }, new {id=gameId} );

        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
