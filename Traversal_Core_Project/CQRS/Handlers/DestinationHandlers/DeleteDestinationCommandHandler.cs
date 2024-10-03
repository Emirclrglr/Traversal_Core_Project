using DataAccessLayer.Concrete;
using Traversal_Core_Project.CQRS.Commands.DestinationCommands;

namespace Traversal_Core_Project.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.id);
            _context.Remove(value);
            _context.SaveChanges();
        }
    }
}
