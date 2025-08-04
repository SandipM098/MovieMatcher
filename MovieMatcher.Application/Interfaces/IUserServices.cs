using MovieMatcher.Application.DTOs.Users;
using MovieMatcher.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Interfaces
{
    public interface IUserServices
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<string?> LoginUserAsync(LoginUserDto loginUserDto);

        Task<bool> DeleteUserByIdAsync(string? id);

        Task<bool> ConfirmEmailAsync(string email, string token);

        Task<ResetPasswordResponse> RequestResetPasswordAsync(string email);
        Task<bool?> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

    }
}
