using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Core_Project.CQRS.Commands.GuideCommands;

namespace Traversal_Core_Project.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideCommandHandler : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var val = await _context.Guides.FindAsync(request.id);
            _context.Remove(val);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
