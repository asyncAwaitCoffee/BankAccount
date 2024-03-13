using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBank2App.DTO;
using WebBank2App.Repositories;

namespace WebBank2App.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromServices] IUsersRepository usersRepository, [FromForm] LoginDTO login, [FromQuery] string? ReturnUrl)
        {
            (string userName, string password) = login;
            int? userId = usersRepository.TryLogin(userName, password);
            if (!userId.HasValue)
            {
                return Unauthorized();
            }

            List<Claim> claims = [new(ClaimTypes.Name, userName), new(ClaimTypes.Sid, userId.ToString()!)];
            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Json(new { result = ReturnUrl ?? "/"});
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
