using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _CardsStatistics2 : ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {

            return View();
        }
    
    }
}
