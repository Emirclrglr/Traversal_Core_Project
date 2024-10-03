using DataAccessLayer.Concrete;
using Traversal_Core_Project.CQRS.Commands.DestinationCommands;
using Traversal_Core_Project.CQRS.Results.DestinationResults;

namespace Traversal_Core_Project.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.Id);
            value.City = command.City;
            value.Price = command.Price;
            value.LengthOfStay = command.LengthOfStay;
            value.Capacity = command.Capacity;
            value.Image = command.Image;
            _context.SaveChanges();
          
        }
    }
}
