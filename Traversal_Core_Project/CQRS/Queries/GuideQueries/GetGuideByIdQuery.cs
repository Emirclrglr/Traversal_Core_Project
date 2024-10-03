using MediatR;
using Traversal_Core_Project.CQRS.Results.GuideResults;

namespace Traversal_Core_Project.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery:IRequest<GetGuideByIdQueryResult>
    {
        public int Id { get; set; }

        public GetGuideByIdQuery(int id)
        {
            Id = id;
        }
    }
}
