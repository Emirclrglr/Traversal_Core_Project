using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.MemberLayout
{
    public class _MemberNavBarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberNavBarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.User = user.FirstName + " " + user.LastName;
            return View();
        }
    }
}
