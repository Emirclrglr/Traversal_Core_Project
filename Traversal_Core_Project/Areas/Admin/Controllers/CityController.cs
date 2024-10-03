using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Core_Project.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {

        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int id)
        {
            var value = _destinationService.TGetByID(id);
            var jsonValues = JsonConvert.SerializeObject(value);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            
            return NoContent();
        }
        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var jsonValue = JsonConvert.SerializeObject(destination);
            return Json(jsonValue);
        }

    }
}
