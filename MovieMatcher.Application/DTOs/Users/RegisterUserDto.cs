using System;
using System.ComponentModel.DataAnnotations;

namespace MovieMatcher.Application.DTOs.Users
{
    public class RegisterUserDto
    {
        [MaxLength(20, ErrorMessage = "User name must be less than 20 characters")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        [MaxLength(100, ErrorMessage = "Password must be less than 100 characters")]
        [RegularExpression(
            @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_\-+=]).{6,100}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
