using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Controllers.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}