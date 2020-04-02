using LibraryAssistant.Data;
using LibraryAssistant.Resources.Response;
using LibraryAssistant.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAssistant.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly LibraryAssistantDbContext _context;

        public AuthenticationService(UserManager<IdentityUser> userManager, IOptions<JwtSettings> jwtSettings, LibraryAssistantDbContext Context)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _context = Context;
        }

        public async Task<AuthenticationResultResponse> RegisterAsync(string email, string password, string username)
        {
            var userExist = await _userManager.FindByEmailAsync(email);

            if (userExist != null)
            {
                return new AuthenticationResultResponse
                {
                    ErrorMessages = new[] { "User with this email address already exists" },
                    StatusCodes = StatusCodes.Status200OK,
                    Success = true
                };
            }

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = username
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResultResponse
                {
                    StatusCodes = StatusCodes.Status200OK,
                    Success = false,
                    ErrorMessages = createdUser.Errors.Select(x => x.Description),
                    
                };
            }

            return GenerateTokenAsync(newUser);
        }

        public async Task<AuthenticationResultResponse> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationResultResponse
                {
                    StatusCodes = StatusCodes.Status204NoContent,
                    ErrorMessages = new[] { "User with this email does not exist" },
                    Success = true,

                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResultResponse
                {
                    StatusCodes = StatusCodes.Status200OK,
                    ErrorMessages = new[] { "Incorrect Password" },
                    Success = true,
                };
            }

            return GenerateTokenAsync(user);
        }

        private AuthenticationResultResponse GenerateTokenAsync(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim("id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResultResponse
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                StatusCodes = StatusCodes.Status200OK
            };


        }

    }
}
