using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementList_DTO>>(_announcementService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAnnouncement(Create_Announcement_DTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TInsert(new()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AnnouncementDate = DateTime.Parse(DateTime.Now.ToString())
                });

                return RedirectToAction("Announcement", "Admin", "Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<Update_Announcement_DTO>(_announcementService.TGetByID(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(Update_Announcement_DTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content,
                    AnnouncementDate = model.AnnouncementDate
                });
                return RedirectToAction("Announcement", "Admin", "Index");
            }
            return View(model);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetByID(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Announcement", "Admin", "Index");

        }
    }
}
