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

        // POST: Handle Login Form Submission
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

            if (user != null && user.Password == password)
            {
                HttpContext.Session.SetString("UserId", user.Id);
                HttpContext.Session.SetString("RoleName", user.Role.Ten);

                if (user.Role.Ten == "Admin")
                {
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

        // Logout action
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Unauthorized access page
        [HttpGet("UnauthorizedAccess")]
        public IActionResult UnauthorizedAccess()
        {
            return View("403");
        }

    }
}
