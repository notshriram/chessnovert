﻿using Chessnovert.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

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
        //GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
