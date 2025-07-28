using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Domain.Entities
{
    public class Friendship
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId   { get; set; }
        public FriendshipStatus Status { get; set; }
    }

    public enum FriendshipStatus
    {
        Pending,
        Accepted,
        Rejected,
        Blocked
    }
}
