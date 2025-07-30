//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using MovieMatcher.Domain.Entities;
//using MovieMatcher.Shared;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace MovieMatcher.Infrastructure.Helpers
//{
//    public class JwtTokenGenerator
//    {
//        private readonly JwtSettings _jwtSettings;

//        public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
//        {
//            _jwtSettings = jwtOptions.Value;
//        }

//        public string GenerateToken(AppUser user)
//        {
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//                new Claim(JwtRegisteredClaimNames.Email, user.Email),
//                new Claim("Username", user.UserName)
//            };

//            var token = new JwtSecurityToken(
//                issuer: _jwtSettings.Issuer,
//                audience: _jwtSettings.Audience,
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
