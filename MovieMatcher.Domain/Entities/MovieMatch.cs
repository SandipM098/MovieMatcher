using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Domain.Entities
{

    public class MovieMatch
    {
        public int Id { get; set; }

        public int User1Id { get; set; }
        public AppUser User1 { get; set; }

        public int User2Id { get; set; }
        public AppUser User2 { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime MatchedOn { get; set; } = DateTime.UtcNow;
    }

}
