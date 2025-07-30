using MovieMatcher.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<string?> LoginUserAsync(LoginUserDto loginUserDto);

        Task<bool> DeleteUserByIdAsync(int id);

        Task<string?> UpdateUserByIdAsync(int id, UpdateUserDto updateUserDto);
    }
}
