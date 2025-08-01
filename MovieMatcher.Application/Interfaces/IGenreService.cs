using MovieMatcher.Application.DTOs.Genre;
using MovieMatcher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Interfaces
{
    public interface IGenreService
    {
        Task<Genre?> CreateNewGenreAsync(CreateGenreDto createGenreDto);
        Task<Genre?> GetGenreByIdAsync(int id);
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> UpdateGenreAsync(int id, UpdateGenreDto updateGenreDto);
        Task<bool> DeleteGenreAsync(int id);
    }
}
