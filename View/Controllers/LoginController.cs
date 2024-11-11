using DemoBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace View.Controllers
{
    [Route("Login")]
    public class LoginController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DbContextShop _context;

        public LoginController(DbContextShop context)
        {
            _context = context;
        }

        // GET: Show Login Page
        [HttpGet("")]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Username and password are required";
                return View();
            }

            var user = await _context.User.Include(u => u.Role)
                               .FirstOrDefaultAsync(u => u.Username == username);


            if (user != null && user.Password.Equals(password))
            {
                HttpContext.Session.SetString("UserId", user.Id.ToLower());
                HttpContext.Session.SetString("Username", user.Username.ToLower());

                if (user.Role.Ten == "Admin")
                {
                    HttpContext.Session.SetString("Role", user.Role.Ten);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess");
                }
            }

            ViewBag.ErrorMessage = "Invalid username or password!";
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet("UnauthorizedAccess")]
        public IActionResult UnauthorizedAccess()
        {
            return View("403");
        }

    }
}
