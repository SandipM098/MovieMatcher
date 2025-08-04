using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Response
{
    public class RegisterResponse
    {
        public string Message { get; set; }
        public string? EmailConfirmationLink { get; set; }
        public bool isSuccess { get; set; }
        public RegisterResponse(bool success ,string message, string? emailConfirmationLink = null)
        {
            isSuccess = isSuccess;
            Message = message;
            EmailConfirmationLink = emailConfirmationLink;
        }
    }
}
