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
            _logger.LogInformation("Test sayfasý çaðýrýldý");
            return View();
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfasý çaðýrýldý");
            _logger.LogError("Error log çaðýrýldý");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _logger.LogInformation($"{date} Privacy sayfasý çaðýrýldý");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
