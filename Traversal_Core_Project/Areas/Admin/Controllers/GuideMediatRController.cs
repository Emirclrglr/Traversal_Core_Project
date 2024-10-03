using MediatR;
using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.CQRS.Commands.GuideCommands;
using Traversal_Core_Project.CQRS.Queries.GuideQueries;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("GuideMediatR","Admin","Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {
            var value = await _mediator.Send(new  GetGuideByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuide(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("GuideMediatR", "Admin", "Index");
            
        }

        public async Task<IActionResult> DeleteGuide(int id)
        {
            await _mediator.Send(new DeleteGuideCommand(id));
            return RedirectToAction("GuideMediatR", "Admin", "Index");

        }
    }
}
