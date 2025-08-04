using Microsoft.EntityFrameworkCore;
using MovieMatcher.Domain.Entities;
using System;

namespace MovieMatcher.Infrastructure
{
    public static class DbSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" },
                new Genre { Id = 4, Name = "Horror" },
                new Genre { Id = 5, Name = "Romance" },
                new Genre { Id = 6, Name = "Sci-Fi" },
                new Genre { Id = 7, Name = "Thriller" },
                new Genre { Id = 8, Name = "Fantasy" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Overview = "A dream heist thriller.", ReleaseDate = new DateTime(2010, 7, 16) },
                new Movie { Id = 2, Title = "The Hangover", Overview = "A wild Vegas trip.", ReleaseDate = new DateTime(2009, 6, 5) }
            );

            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre { Id = 1, MovieId = 1, GenreId = 1 },
                new MovieGenre { Id = 2, MovieId = 1, GenreId = 2 },
                new MovieGenre { Id = 3, MovieId = 2, GenreId = 3 },
                new MovieGenre { Id = 4, MovieId = 2, GenreId = 4 }
            );
        }
    }
}
