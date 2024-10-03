namespace Traversal_Core_Project.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string LengthOfStay { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Capacity { get; set; }
    }
}
