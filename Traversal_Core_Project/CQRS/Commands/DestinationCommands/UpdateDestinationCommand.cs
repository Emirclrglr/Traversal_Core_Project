namespace Traversal_Core_Project.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int Id { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string LengthOfStay { get; set; }
        public int Capacity { get; set; }
        public string Image { get; set; }
    }
}
