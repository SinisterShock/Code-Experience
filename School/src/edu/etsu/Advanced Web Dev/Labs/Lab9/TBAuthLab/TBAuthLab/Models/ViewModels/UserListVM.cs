using System.ComponentModel.DataAnnotations;

namespace TBAuthLab.Models.ViewModels
{
    public class UserListVM
    {
        public string? Email { get; set; }
        public string? Username { get; set; }

        [Display(Name = "Number of roles")]
        public int NumberOfRoles { get; set; }
        [Display(Name = "Role names")]
        public string? RoleNames { get; set; }
    }
}
