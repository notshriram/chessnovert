using Chessnovert.Services;
using Chessnovert.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chessnovert.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningsController : ControllerBase
    {
        private readonly OpeningBookService openingBookService;

        public OpeningsController(OpeningBookService openingBookService)
        {
            this.openingBookService = openingBookService;
        }

        // GET api/<OpeningsController>/
        [HttpGet]
        public IActionResult Get([FromBody] string UCI)
        {
            Opening? opening = openingBookService.GetFromUCI(UCI);
            if(opening == null)
            {
                NotFound(UCI);
            }    
            return Ok(opening);
        }
    }
}
