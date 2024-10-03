using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = user.FirstName + " " + user.LastName;
            ViewBag.Image = user.ImageUrl;
            return View();
        }        

        public IActionResult Deneme()
        {
            return View();
        }

        public async Task<IActionResult> MemberDashboard()
        {
            return View();
        }
  
    }
}
