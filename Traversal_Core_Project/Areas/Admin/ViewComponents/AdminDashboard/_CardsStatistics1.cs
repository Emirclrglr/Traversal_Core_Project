using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _CardsStatistics1 : ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.stats1 = context.Destinations.Count();
            ViewBag.stats2 = context.Users.Count();
            return View();
        }
    }
}
