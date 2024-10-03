using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Core_Project.CQRS.Queries.GuideQueries;
using Traversal_Core_Project.CQRS.Results.DestinationResults;
using Traversal_Core_Project.CQRS.Results.GuideResults;

namespace Traversal_Core_Project.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Image = value.Image,
                InstagramUrl = value.InstagramUrl,
                TwitterUrl = value.TwitterUrl,
                Status = value.Status
            };
        }
    }
}
