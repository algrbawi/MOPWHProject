using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models
{
    public class LoginViewModel
    {
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RemmberMe { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
