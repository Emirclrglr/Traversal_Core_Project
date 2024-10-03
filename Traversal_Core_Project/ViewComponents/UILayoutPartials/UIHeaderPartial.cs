using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.UILayoutPartials
{
    public class UIHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
