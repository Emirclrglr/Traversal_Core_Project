using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
