using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Member.ViewComponents.MemberDashboard
{
    public class _PlatformSettings : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
