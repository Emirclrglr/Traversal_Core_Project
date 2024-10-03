using MediatR;

namespace Traversal_Core_Project.CQRS.Commands.GuideCommands
{
    public class UpdateGuideCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool Status { get; set; }
    }
}
