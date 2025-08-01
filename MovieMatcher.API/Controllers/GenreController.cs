using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieMatcher.Application.DTOs.Genre;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Domain.Entities;
using System.Collections;
using System.ComponentModel;

namespace MovieMatcher.API.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto createGenreDto)
        {
            if (createGenreDto == null)
            {
                return BadRequest("Invalid genre data.");
            }
            var genre = await _genreService.CreateNewGenreAsync(createGenreDto);
            if (genre == null)
            {
                return Conflict("Genre already exists.");
            }
            return Ok(genre);
        }

        [HttpGet("all-genre")]
        public async Task<IActionResult> GetAllGenre()
        {
            var genres = await _genreService.GetAllGenresAsync();

            if (!genres.Any())
            {
                return NotFound("No genres found.");
            }   

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return Conflict("No genre found with that id");
            }
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var genre = await _genreService.DeleteGenreAsync(id);
            if (genre != true)
            {
                return Conflict("Error deleting that genre");
            }

            return Ok("Successfully deleted");
        }
    }
}
