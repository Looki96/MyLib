using MyLib.Api.Middleware;
using MyLib.Api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyLib.Api.Services.Factory;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Validation;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyLib.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly MyLibContext _dbContext;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(MyLibContext dbContext, AuthenticationSettings authenticationSettings, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _authenticationSettings = authenticationSettings;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(e => e.Login == loginDto.Login);

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

            if (user == null || result == PasswordVerificationResult.Failed)
            {
                var details = ServerValidationHelper.ServerValidationBadReqest();
                details.Errors = new Dictionary<string, string[]> { { "Login", new string[] { "Invalid Login or Password" } } };
                throw new BadRequestException(JsonSerializer.Serialize(details));
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.SName} {user.Name}"),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
