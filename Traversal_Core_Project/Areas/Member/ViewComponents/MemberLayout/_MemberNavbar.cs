using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Member.ViewComponents.MemberLayout
{
    public class _MemberNavbar:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.FirstName + " " + user.LastName;
            ViewBag.image = user.ImageUrl;
            return View();
        }
    }
}
