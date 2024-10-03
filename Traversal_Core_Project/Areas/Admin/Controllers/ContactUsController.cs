using BusinessLayer.Abstract;
using DTOLayer.DTOs.CityDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;


        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetListByFilter(x => x.Status == true);
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            _contactUsService.TDeleteMessage(id);
            return RedirectToAction("ContactUs","Admin","Index");
        }

        public IActionResult ReadMessage(int id)
        {
            var value = _contactUsService.TGetByID(id);
            return View(value);
        }

    
    }
}
