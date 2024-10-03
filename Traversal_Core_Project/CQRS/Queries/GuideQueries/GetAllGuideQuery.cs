using MediatR;
using Traversal_Core_Project.CQRS.Results.DestinationResults;
using Traversal_Core_Project.CQRS.Results.GuideResults;

namespace Traversal_Core_Project.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
