using Business.Abstract;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Area("Admin")]
    public class AuthsController : ControllerBase
    {
        private IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthsController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

    }
}
