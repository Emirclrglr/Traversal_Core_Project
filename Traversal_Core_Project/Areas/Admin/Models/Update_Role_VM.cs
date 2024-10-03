namespace Traversal_Core_Project.Areas.Admin.Models
{
    public class Update_Role_VM
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
