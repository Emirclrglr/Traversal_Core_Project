using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.ContactUs
{
    public class _Address : ViewComponent
    {
        private readonly IContactService _contactService;

        public _Address(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _contactService.TGetByID(2);
            return View(value);
        }
    }
}
