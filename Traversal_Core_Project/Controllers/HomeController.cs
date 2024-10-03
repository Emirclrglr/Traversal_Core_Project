using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Traversal_Core_Project.Models;

namespace Traversal_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfas� �a��r�ld�");
            return View();
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfas� �a��r�ld�");
            _logger.LogError("Error log �a��r�ld�");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _logger.LogInformation($"{date} Privacy sayfas� �a��r�ld�");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
