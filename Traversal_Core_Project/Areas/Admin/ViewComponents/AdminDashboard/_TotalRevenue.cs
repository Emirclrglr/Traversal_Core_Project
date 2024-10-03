using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _TotalRevenue:ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
