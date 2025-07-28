using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Overview { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double? Rating { get; set; }

        public ICollection<UserLikedMovie> MovieLiked { get; set; }
        public ICollection<WatchHistory> MovieWatched { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
    }
}
