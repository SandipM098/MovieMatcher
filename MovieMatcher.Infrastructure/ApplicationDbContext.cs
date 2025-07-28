using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMatcher.Domain.Entities;

namespace MovieMatcher.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbSeeder.SeedData(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserLikedMovie> UserLikedMovies { get; set; }  
        public DbSet<WatchHistory> WatchHistories { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
    }
}
