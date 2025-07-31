using System.Security.Claims;
using MovieMatcher.Domain.Entities;

namespace MovieMatcher.Application.Interfaces;


public interface IJwtTokenGenerator
{
    string GenerateAccessToken(AppUser user, List<Claim>? additionalClaims = null);
}
