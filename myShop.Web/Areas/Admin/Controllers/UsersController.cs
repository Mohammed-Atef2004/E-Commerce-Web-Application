using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myShop.DAL.Data;
using myShop.DAL.Models;
using myShop.BLL;
using System.Security.Claims;

namespace myShop.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles =SD.AdminRole)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);//will give us the logged in user id
            var userId =claim.Value;
            List<ApplicationUser> users = _context.ApplicationUsers.Where(u => u.Id != userId).ToList();
            return View(users);
        }
    }
}
