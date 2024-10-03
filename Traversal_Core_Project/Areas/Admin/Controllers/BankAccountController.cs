using BusinessLayer.Abstract.AbstractUoW;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BankAccountController : Controller
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BankAccountVM model)
        {
            var valueSender = _bankAccountService.TGetById(model.SenderId);
            var valueReceiver = _bankAccountService.TGetById(model.ReceiverId);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<BankAccount> modifiedAccounts = new()
            {
                valueSender,
                valueReceiver
            };

            _bankAccountService.TMultiUpdate(modifiedAccounts);

            return View();
        }
    }
}
