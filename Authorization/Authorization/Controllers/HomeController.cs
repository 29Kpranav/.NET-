using Authorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Authorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secured()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["returnedUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost("Home/Login")]
        public IActionResult Verify(string username, string password, string ReturnUrl)
        {
            if(username == "sam" && password == "sam")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username)); 
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                ClaimsIdentity claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal clamsPrincipal = new ClaimsPrincipal(claimsidentity);

                HttpContext.SignInAsync(clamsPrincipal);
                return Redirect(ReturnUrl);
            }
            return BadRequest();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}