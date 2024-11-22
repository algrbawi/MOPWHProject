namespace aspnetcore.ntier.Dashboard.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RemmberMe { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
