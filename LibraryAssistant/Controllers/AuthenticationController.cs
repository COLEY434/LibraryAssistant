using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAssistant.Extensions;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Services.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAssistant.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]       
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

         
                var authResponse = await _authService.LoginAsync(request.Email, request.Password);

                if (!authResponse.Success)
                {
                    return Ok(authResponse);
                }

                return Ok(authResponse);
     
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            
                var authResponse = await _authService.RegisterAsync(request.Email, request.Password, request.Username);

                if (!authResponse.Success)
                {
                    return Ok(authResponse);
                }

                return Ok(authResponse);

        }

    }
}