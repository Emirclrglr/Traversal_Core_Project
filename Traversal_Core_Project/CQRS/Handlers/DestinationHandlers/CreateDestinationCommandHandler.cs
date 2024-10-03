using DataAccessLayer.Concrete;
using Traversal_Core_Project.CQRS.Commands.DestinationCommands;

namespace Traversal_Core_Project.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new()
            {
                City = command.City,
                Capacity = command.Capacity,
                LengthOfStay = command.LengthOfStay,
                Price = command.Price,
                Status = true,
                Image = command.Image
            });
            _context.SaveChanges();
        }
    }
}
