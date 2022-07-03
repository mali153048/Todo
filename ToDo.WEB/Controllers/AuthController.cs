using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Application.Contracts.Services;
using ToDo.Application.DTO;

namespace ToDo.WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO viewModel)
        {
            TempData.Clear();

            var response = await _authService.AuthenticateAsync(viewModel).ConfigureAwait(false);

            if (response.Success)
            {
                var claimsIdentity = new ClaimsIdentity(
                                    response.Claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                return RedirectToAction("index", "home");
            }
            else
            {
                TempData["loginErrors"] = response.ValidationErrors;
            }

            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO viewModel)
        {
            TempData.Clear();

            var response = await _authService.RegisterAsync(viewModel).ConfigureAwait(false);

            if (response.Success)
            {
                return View("Login");
            }

            TempData["registerationErrors"] = response.ValidationErrors;

            return RedirectToAction("Register");
        }


        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies").ConfigureAwait(false);
            return RedirectToAction("login");
        }

    }
}
