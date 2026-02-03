using Application.DTOs;
using Application.Service.Abstraction;
using Application.Validations;
using Domain.Entities;
using Domain.RepositoryAbstraction;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared_Kernal.Guards;
using Shared_Kernal.Security;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Service
{

    public class AuthService : IAuthService
    {
        // Inject your DbContext or repository here
        private readonly IUserRepository _ctx;
        private readonly string _jwtSecret;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public AuthService(IUserRepository ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            _jwtSecret = configuration["Jwt:Secret"];
            _jwtIssuer = configuration["Jwt:Issuer"];
            _jwtAudience = configuration["Jwt:Audience"];
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var validation = new LoginValidation();
            var validationResponse = validation.Validate(request);

            if (validationResponse.IsValid is false)
                throw new BusinessLogicException(validationResponse.Errors.FirstOrDefault().ErrorMessage);
            
            var user = await _ctx.GetByUsernameAsync(request.Email);
            if (user == null)
                throw new Exception("Invalid credentials");

            var incomingPasswordHash = SecurityUtilities.HashPassword(request.Password);
            if (user.Password != incomingPasswordHash)
                throw new Exception("Invalid credentials");

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Token = token
            };
        }

     
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            // Example logic, replace with your own
            var exists = await _ctx.GetByUsernameAsync(request.UserName);
            if (exists != null)
                throw new BusinessLogicException("User already registered");
            var user = new User(request.UserName, request.Password);
            var createdUser = await _ctx.CreateUserAsync(user);
            var token = GenerateJwtToken(createdUser);

            return new AuthResponseDto
            {
                UserId = createdUser.Id,
                Username = createdUser.Username,
                Token = token
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString())
            };

            // Ensure the secret is not null or empty and is of sufficient length
            var keyBytes = System.Text.Encoding.UTF8.GetBytes(_jwtSecret);
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtAudience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
