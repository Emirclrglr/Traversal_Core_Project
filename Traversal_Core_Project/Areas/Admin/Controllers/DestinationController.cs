using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
       readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            p.Status = true;
            _destinationService.TInsert(p);
            return RedirectToAction("Destination", "Admin", "Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            _destinationService.TDelete(value);
            return RedirectToAction("Destination","Admin","Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return RedirectToAction("Destination", "Admin", "Index");
        }

    }
}
