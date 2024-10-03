using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal_Core_Project.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }

        private void DestinationDropDownList()
        {
            using var c = new Context();
            List<SelectListItem> list = (from x in c.Destinations
                                         select new SelectListItem
                                         {
                                             Text = x.City,
                                             Value = x.Id.ToString()
                                         }).ToList();
            ViewBag.list = list;
        }
        public async Task<IActionResult> MyReservations()
        {
            ViewBag.Header = "Rezervasyonlarım";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetListWithDestinationByFilter(x=>x.AppUserId == user.Id && x.Status == "Onaylandı");
            return View(values);
        }
        public async Task<IActionResult> ReservationHistory()
        {
            ViewBag.Header = "Geçmiş Rezervasyonlarım";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetListWithDestinationByFilter(x => x.AppUserId == user.Id && x.Status == "İşlem Yapıldı");
            return View(values);
        }
        public async Task<IActionResult> MyApprovalReservations()
        {
            ViewBag.Header = "Onay Bekleyen Rezervasyonlarım";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetListWithDestinationByFilter(x => x.AppUserId == user.Id && x.Status == "Onay Bekliyor");
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateReservation()
        {
            ViewBag.Header = "Rezervasyon Yap";
            DestinationDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation p)
        {
            ViewBag.Header = "Rezervasyon Yap";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            DestinationDropDownList();
            p.AppUserId = user.Id;
            p.Status = "Onay Bekliyor";
            _reservationService.TInsert(p);
            return RedirectToAction("MyReservations");
        }
    }
}
