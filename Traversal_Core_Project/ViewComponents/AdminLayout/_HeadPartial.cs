using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.AdminLayout
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
