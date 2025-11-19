using GymProjectBackend.Entities;
using GymProjectBackend.Models.Auth;
using GymProjectBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<SignUpResponseDTO>> Register(UserDTO request)
        {
            var response = await authService.RegisterAsync(request);

            if (response is null)
                return BadRequest("Username already exists");

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(UserDTO request)
        {

            var tokensResult = await authService.LoginAsync(request);

            if (tokensResult is null)
            {
                return BadRequest("Username or password is incorrect");
            }

            return Ok(tokensResult);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenDTO request)
        {
            var result = await authService.RefreshTokensAsync(request);

            if(result is null || result.RefreshToken is null || result.AccessToken is null)
            {
                return Unauthorized("Invalid Refresh Token");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoints()
        {
            return Ok("You are authenticated");
        }

    }
}
