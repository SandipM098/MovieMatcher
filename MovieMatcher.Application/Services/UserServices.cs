using Microsoft.AspNetCore.Identity;
using MovieMatcher.Application.DTOs.Users;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Application.Response;
using MovieMatcher.Domain.Entities;
using MovieMatcher.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMatcher.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserServices(
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<string?> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if (user == null)
            {
                return "User not found";
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (!passwordValid)
            {
                return "Invalid password";
            }

            if (!user.EmailConfirmed)
            {
                return "Email not confirmed";
            }

            var token = _jwtTokenGenerator.GenerateAccessToken(user);
            return token;
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerUserDto.Email);
            if (existingUser != null)
            {
                return new RegisterResponse(false, "User with that email already exists");
            }

            var newUser = new AppUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email
            };

            var createResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createResult.Succeeded)
            {
                var errorMsg = string.Join("; ", createResult.Errors.Select(e => e.Description));
                return new RegisterResponse(false, $"User creation failed: {errorMsg}");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var encodedToken = HttpUtility.UrlEncode(token);

            var confirmationLink = $"https://localhost:7083/api/auth/confirm-email?userId={newUser.Id}&token={encodedToken}";

            return new RegisterResponse(true, "User registered successfully. Check your email to confirm.", confirmationLink);
        }

        public async Task<bool> DeleteUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            var deleteResult = await _userManager.DeleteAsync(user);
            return deleteResult.Succeeded;
        }

        public Task<string?> UpdateUserByIdAsync(string id, UpdateUserDto updateUserDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var decodedToken = HttpUtility.UrlDecode(token);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            return result.Succeeded;
        }

        public Task<bool> DeleteUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string?> UpdateUserByIdAsync(int id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
