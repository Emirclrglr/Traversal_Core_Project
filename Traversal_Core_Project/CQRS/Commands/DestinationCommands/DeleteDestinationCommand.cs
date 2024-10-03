namespace Traversal_Core_Project.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            this.id = id;
        }
        public int id { get; set; }
        
    }
}
