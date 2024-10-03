using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Traversal_Core_Project.CQRS.Results.DestinationResults;

namespace Traversal_Core_Project.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public IEnumerable<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.Id,
                Capacity = x.Capacity,
                City = x.City,
                LengthOfStay = x.LengthOfStay,
                Image = x.Image,
                Price = x.Price
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
