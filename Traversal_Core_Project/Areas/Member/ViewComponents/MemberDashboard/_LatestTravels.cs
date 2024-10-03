using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Member.ViewComponents.MemberDashboard
{
    public class _LatestTravels : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LatestTravels(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4Destinations();
            return View(values);
        }

    }
}
