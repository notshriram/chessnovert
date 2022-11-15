using Chessnovert.Services;
using Chessnovert.Shared;
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
        //GET: api/Games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            try
            {
                var games = gameService.GetAll();
                return Ok(games);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Games/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetGame(Guid id)
        {
            try
            {
                var game = gameService.Get(id);
                return Ok(game);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/Games
        [HttpPost]
        public IActionResult Post([FromBody] TimeSpan timeControl)
        {
            try
            {
                Game newGame = new Game { Id = Guid.NewGuid(), TimeControl=timeControl };
                gameService.Create(newGame);
                return CreatedAtAction(nameof(GetGame), new { id = newGame.Id }, newGame);
            }
            catch
            {
                return Conflict();
            }

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
