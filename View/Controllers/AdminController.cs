using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        public IActionResult CartIndex()
        {
            return View();
        }
        public IActionResult OrdersList()
        {
            return View();
        }
        public IActionResult Bills()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult UserCreate()
        {
            return View();
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
