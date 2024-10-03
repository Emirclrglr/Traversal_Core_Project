using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
            
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Rotalar";

            var values = _destinationService.TGetList();
            return View(values);
        }

        public IActionResult DestinationDetails(int id)
        {
            
            ViewBag.id = id;
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Tur Detayları";

            var values = _destinationService.TGetDestinationByIdWithGuide(id);
            return View(values);
        }
    }
}
