using Microsoft.AspNetCore.Mvc;
using MovieMatcher.Application.DTOs.Users;
using MovieMatcher.Application.Interfaces;

namespace MovieMatcher.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;   
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }
            var result = await _userServices.RegisterUserAsync(registerUserDto);
            if (result)
            {
                return Ok("User registered successfully.");
            }
            else
            {
                return Conflict("User already exists.");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            if (loginUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }
            var result = await _userServices.LoginUserAsync(loginUserDto);
            return Ok(result);
        }
    }
}
