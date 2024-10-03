using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.FeatureDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<List_Feature_DTO>>(_featureService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(Create_Feature_DTO model)
        {
            if (ModelState.IsValid)
            {
                _featureService.TInsert(new()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image,
                    Status = true
                });
                return RedirectToAction("Feature","Admin","Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _mapper.Map<Update_Feature_DTO>(_featureService.TGetByID(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Update_Feature_DTO model)
        {
            if (ModelState.IsValid)
            {
                _featureService.TUpdate(new()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image,
                    Status = model.Status
                    
                });
                return RedirectToAction("Feature", "Admin", "Index");
            }
            return View();
        }

        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return RedirectToAction("Feature", "Admin", "Index");
        }
    }
}

