using Controller.DTO;
using DemoBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace View.Controllers
{
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DbContextShop _context;

        public UserController(DbContextShop context)
        {
            _context = context;
        }
        private bool IsAdmin()
        {
            var role = HttpContext.Session.GetString("Role");
            return role != null && role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        [HttpGet("User/Index")]
        public async Task<IActionResult> Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("UnauthorizedAccess", "Login");
            }

            var users = await _context.User.Include(u => u.Role).ToListAsync();
            var roles = await _context.Role.ToListAsync();

            ViewBag.Roles = roles;
            return View(users);
        }

        // POST: User/UpdateRole
        [HttpPost]
        public IActionResult UpdateRole(string userId, string roleId)
        {
            if (!IsAdmin())
            {
                return Json(new { success = false, message = "Unauthorized access" });
            }

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleId))
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var user = _context.User.Find(userId);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            user.RoleId = roleId;
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
