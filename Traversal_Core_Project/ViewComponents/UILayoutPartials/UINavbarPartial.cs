using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.UILayoutPartials
{
    public class UINavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
