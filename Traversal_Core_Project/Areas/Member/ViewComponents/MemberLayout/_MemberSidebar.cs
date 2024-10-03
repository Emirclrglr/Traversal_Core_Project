using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Member.ViewComponents.MemberLayout
{
    public class _MemberSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
