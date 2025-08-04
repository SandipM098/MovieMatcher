using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Response
{
    public class ResetPasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Link { get; set; }
        public ResetPasswordResponse(bool isSuccess, string email, string token, string link, string? message = null )
        {
            IsSuccess = isSuccess;
            Message = message;
            Email = email;
            Token = token;
            Link = link;
        }
    }
}
