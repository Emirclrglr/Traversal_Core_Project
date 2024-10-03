using DataAccessLayer.Concrete;
using Traversal_Core_Project.CQRS.Queries;
using Traversal_Core_Project.CQRS.Results.DestinationResults;

namespace Traversal_Core_Project.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIdQuery query)
        {
            var value = _context.Destinations.Find(query.Id);
            return new GetDestinationByIDQueryResult
            {
                Id = value.Id,
                Capacity = value.Capacity,
                City = value.City,
                LengthOfStay = value.LengthOfStay,
                Price = value.Price,
                Image = value.Image
                
            };
        }
    }
}
