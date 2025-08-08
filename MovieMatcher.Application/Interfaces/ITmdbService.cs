using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Interfaces
{
    public interface ITmdbService
    {
        Task<string?> GetPopularMovieAsync(int page = 1);
        Task<string?> SearchMovieAsync(string query, int page = 1);
    }
}
