﻿using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Traversal_Core_Project.CQRS.Queries.GuideQueries;
using Traversal_Core_Project.CQRS.Results.DestinationResults;
using Traversal_Core_Project.CQRS.Results.GuideResults;

namespace Traversal_Core_Project.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).AsNoTracking().ToListAsync();
        }
    }
}
