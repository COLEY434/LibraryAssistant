using LibraryAssistant.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultResponse> LoginAsync(string email, string password);
        Task<AuthenticationResultResponse> RegisterAsync(string email, string password, string username);
    }
}
