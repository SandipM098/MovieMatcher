using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string? ProfileImageUrl{ get; set; }
           
        // Navigation // One user can have many
        public ICollection<UserLikedMovie> LikedMovies { get; set; }
        public ICollection<WatchHistory> WatchHistories { get; set; }
        public ICollection<Friendship> Friendships { get; set; }

    }
}