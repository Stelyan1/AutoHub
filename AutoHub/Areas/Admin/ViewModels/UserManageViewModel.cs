namespace AutoHub.Areas.Admin.ViewModels
{
    public class UserManageViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; } 
        public string UserName { get; set; }

        public List<string> UserRoles { get; set; } = new List<string>();
    }
}
