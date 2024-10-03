namespace Traversal_Core_Project.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public string? City { get; set; }
        public string? LengthOfStay { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string Image { get; set; }
    }
}
