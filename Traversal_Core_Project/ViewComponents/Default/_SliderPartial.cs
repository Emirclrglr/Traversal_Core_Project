using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
