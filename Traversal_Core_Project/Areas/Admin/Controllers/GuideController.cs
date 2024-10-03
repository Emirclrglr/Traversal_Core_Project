using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            p.Status = true;
            _guideService.TInsert(p);
            
            return RedirectToAction("Guide", "Admin", "Index");
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Guide", "Admin", "Index");
        }

        public IActionResult SetStatusPassive(int id)
        {
            _guideService.TSetStatusPassive(id);
            return RedirectToAction("Guide", "Admin", "Index");
        }
        public IActionResult SetStatusActive(int id)
        {
            _guideService.TSetStatusActive(id);
            return RedirectToAction("Guide", "Admin", "Index");
        }
    }
}
