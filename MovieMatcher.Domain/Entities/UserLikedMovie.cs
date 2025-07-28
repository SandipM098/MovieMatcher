﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Domain.Entities
{
    public class UserLikedMovie
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime LikedAt { get; set; }
    }
}
