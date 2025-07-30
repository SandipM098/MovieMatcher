using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieMatcher.Application.DTOs.Users;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Domain.Entities;
using MovieMatcher.Infrastructure;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        // You can add a password hasher here if you want to hash passwords
        private readonly PasswordHasher<AppUser> _passwordHasher;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<AppUser>();
        }

        public async Task<string?> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == loginUserDto.Email);

            if (user == null)
            {
                return "User not found";
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.PasswordHash);
            if (result == PasswordVerificationResult.Success)
            {
                return user.UserName;
            }

            return null;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Email == registerUserDto.Email);

            if (existingUser != null)
                return false;

            var newUser = new AppUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registerUserDto.PasswordHash);
            _context.AppUsers.Add(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
