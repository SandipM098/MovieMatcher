using Microsoft.EntityFrameworkCore;
using MovieMatcher.Application.DTOs.Genre;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Domain.Entities;
using MovieMatcher.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre?> CreateNewGenreAsync(CreateGenreDto createGenreDto)
        {
            var existingGenre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Name.ToLower() == createGenreDto.Name.ToLower());
            if (existingGenre != null)
            {
                return null;
            }
            var newGenre = new Genre
            {
                Name = createGenreDto.Name
            };
            await _context.Genres.AddAsync(newGenre);
            await _context.SaveChangesAsync();
            return newGenre;
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return false;
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            var allGenres = await _context.Genres.ToListAsync();

            if (allGenres == null || !allGenres.Any())
            {
                return Enumerable.Empty<Genre>();
            }

            return allGenres;
        }

        public async Task<Genre?> GetGenreByIdAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return null;
            }
            return genre;
        }

        public async Task<Genre?> UpdateGenreAsync(int id, string name)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return null;
            }

            genre.Name = name;
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
