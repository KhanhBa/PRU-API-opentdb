using System.Threading.Tasks;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using TriviaApi.Models;

namespace TriviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        private readonly TriviaService _triviaService;

        public TriviaController(TriviaService triviaService)
        {
            _triviaService = triviaService;
        }

        [HttpGet]
        public async Task<ActionResult<TriviaResponse>> GetTriviaQuestions([FromQuery] int amount = 10, [FromQuery] string difficulty = "easy")
        {
            var triviaResponse = await _triviaService.GetTriviaQuestionsAsync(amount, difficulty);
            return Ok(triviaResponse);
        }
    }
}
