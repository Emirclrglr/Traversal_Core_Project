using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Core_Project.CQRS.Commands.GuideCommands;

namespace Traversal_Core_Project.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync(request.Id);
            value.Name = request.Name;
            value.Description = request.Description;
            value.Status = request.Status;
            value.TwitterUrl = request.TwitterUrl;
            value.InstagramUrl = request.InstagramUrl;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
