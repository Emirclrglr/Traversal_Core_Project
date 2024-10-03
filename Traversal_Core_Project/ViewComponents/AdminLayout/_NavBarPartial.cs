using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.AdminLayout
{
    public class _NavBarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
