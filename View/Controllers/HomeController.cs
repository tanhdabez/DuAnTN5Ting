using DemoBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextShop _context;

        public HomeController(ILogger<HomeController> logger, DbContextShop context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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

        [HttpGet("Home/UserCreate")]
        public IActionResult UserCreate()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("Home/UserCreate")]
        public async Task<IActionResult> UserCreate(User user, Customer customer)
        {
            try
            {
                var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Email đã tồn tại. Vui lòng sử dụng email khác.";
                    return View();
                }

                if (string.IsNullOrEmpty(user.Ma))
                {
                    user.Ma = Guid.NewGuid().ToString();
                }

                user.Id = Guid.NewGuid().ToString();
                user.NgayTao = DateTime.Now;
                user.NgayCapNhat = DateTime.Now;
                user.TrangThai = "Active";
                user.RoleId = "R3";
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                if (string.IsNullOrEmpty(customer.Ma))
                {
                    customer.Ma = Guid.NewGuid().ToString();
                }

                customer.Id = Guid.NewGuid().ToString();
                customer.Ten = user.Email;
                customer.NgayTao = DateTime.Now;
                customer.NgayCapNhat = DateTime.Now;
                customer.TrangThai = "Active";
                customer.Email = user.Email;

                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction("IndexShop", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Đã xảy ra lỗi khi tạo tài khoản: {ex.Message}";
                return View();
            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new View.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
