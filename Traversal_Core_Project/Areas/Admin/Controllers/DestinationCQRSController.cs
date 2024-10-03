using Microsoft.AspNetCore.Mvc;
using Traversal_Core_Project.CQRS.Commands.DestinationCommands;
using Traversal_Core_Project.CQRS.Handlers.DestinationHandlers;
using Traversal_Core_Project.CQRS.Queries;
using Traversal_Core_Project.CQRS.Results.DestinationResults;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestinationById(int id)
        {
            var value = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult GetDestinationById(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("DestinationCQRS", "Admin", "Index");
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("DestinationCQRS", "Admin","Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _deleteDestinationCommandHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("DestinationCQRS", "Admin", "Index");
        }
    }
}
