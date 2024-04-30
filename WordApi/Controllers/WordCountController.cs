using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WordApi.Interfaces;
using WordApi.Models;
using WordApi.Services;

namespace WordApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordCountController : ControllerBase
    {

        private readonly IWordCountService _wordCountService;

        public WordCountController(IWordCountService wordCountService)
        {
            _wordCountService = wordCountService;
        }

        [Consumes(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        public IActionResult Post([FromBody] string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return BadRequest("Inmatningen kan inte vara tom eller bara mellanslag");
            }

            var result = _wordCountService.CountWords(input);

            return Ok(result);
        }
    }
}
