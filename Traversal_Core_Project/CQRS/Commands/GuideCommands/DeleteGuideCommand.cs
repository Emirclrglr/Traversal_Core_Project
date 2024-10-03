using MediatR;

namespace Traversal_Core_Project.CQRS.Commands.GuideCommands
{
    public class DeleteGuideCommand:IRequest
    {
        public int id { get; set; }

        public DeleteGuideCommand(int id)
        {
            this.id = id;
        }
    }
}
