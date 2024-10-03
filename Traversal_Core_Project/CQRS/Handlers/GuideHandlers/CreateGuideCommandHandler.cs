using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Core_Project.CQRS.Commands.GuideCommands;

namespace Traversal_Core_Project.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;
        private readonly IGuideService _guideService;

        public CreateGuideCommandHandler(Context context, IGuideService guideService)
        {
            _context = context;
            _guideService = guideService;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            await _guideService.InsertAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                InstagramUrl = request.InstagramUrl,
                TwitterUrl = request.TwitterUrl,
                Status = true
            });
            return Unit.Value;
        }
    }
}
