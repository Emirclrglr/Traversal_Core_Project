namespace Traversal_Core_Project.CQRS.Queries
{
    public class GetDestinationByIdQuery
    {
        public GetDestinationByIdQuery(int ıd)
        {
            Id = ıd;
        }
        public int Id { get; set; }
    }
}
