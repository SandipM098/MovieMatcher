using global::MovieMatcher.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieMatcher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ITmdbService _tmdbService;

        public MoviesController(ITmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMovies([FromQuery] int page = 1)
        {
            var json = await _tmdbService.GetPopularMovieAsync(page);
            if (json == null) return StatusCode(502, "Failed to fetch data from TMDb");
            return Content(json, "application/json");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string q, [FromQuery] int page = 1)
        {
            var json = await _tmdbService.SearchMovieAsync(q, page);
            if (json == null) return StatusCode(502, "Failed to fetch data from TMDb");
            return Content(json, "application/json");
        }
    }
}
