using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال اسم المستخدم")]
        [RegularExpression(pattern: @"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "صيغة البريد الألكتروني غير صحيحة")]
        public string Email { get; set; }
        [Required(ErrorMessage = "يرجى إدخال كلمة المرور")]
        public string Password { get; set; }
        public bool RemmberMe { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
