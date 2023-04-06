using Business.Abstract;
using Business.Concrete;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (result.Success)
                return Ok(result);
            else
            {
                return Unauthorized();
            }
        }
    }
}
