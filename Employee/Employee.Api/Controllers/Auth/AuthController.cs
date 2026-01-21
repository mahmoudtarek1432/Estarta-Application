using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Service;
using Estarta_Application.Model.Base;
using Application.Service.Abstraction;

namespace Estarta_Application.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseBase<AuthResponseDto>>> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            return ResponseBase<AuthResponseDto>.Success(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseBase<AuthResponseDto>>> Register([FromBody] RegisterRequestDto request)
        {
            var result = await _authService.RegisterAsync(request);
            return ResponseBase<AuthResponseDto>.Success(result);
        }
    }
}
