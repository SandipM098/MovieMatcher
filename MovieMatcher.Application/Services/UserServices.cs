using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MovieMatcher.Application.DTOs.Users;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Application.Response;
using MovieMatcher.Domain.Entities;
using MovieMatcher.Infrastructure;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<AppUser> _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public UserServices(ApplicationDbContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<AppUser>();
            _jwtTokenGenerator = jwtTokenGenerator;
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
                var token = _jwtTokenGenerator.GenerateAccessToken(user);
                return token;
            }

            return null;
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Email == registerUserDto.Email);

            if (existingUser != null)
            {
                return new RegisterResponse(success: false, message: "User with that email already exists");
            }

            var token = Guid.NewGuid().ToString();

            string emailConfirmationLink = $"https://localhost:7083/api/auth/confirm-email?email={registerUserDto.Email}&token={token}";

            var newUser = new AppUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                EmailConfirmationToken = token,
                EmailConfirmed = false,
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registerUserDto.PasswordHash);

            _context.AppUsers.Add(newUser);
            await _context.SaveChangesAsync();

            return new RegisterResponse(
                success: true,
                message : "User registered successfully. Check your email to confirm.",
                emailConfirmationLink : emailConfirmationLink
            );
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<string?> UpdateUserByIdAsync(int id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            if (user.EmailConfirmationToken != token)
            {
                return false;
            }
            user.EmailConfirmed = true;
            user.EmailConfirmationToken = null; 
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
