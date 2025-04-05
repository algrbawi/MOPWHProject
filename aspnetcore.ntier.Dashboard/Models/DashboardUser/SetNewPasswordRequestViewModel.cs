using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class SetNewPasswordRequestViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال كلمة المرور")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,16}$",
ErrorMessage = "يجب أن تكون كلمة المرور بين 8 إلى 16 حرفًا، وتحتوي على حرف كبير واحد على الأقل، وحرف صغير واحد على الأقل، ورقم واحد على الأقل، وحرف خاص واحد على الأقل")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "كلمة لامرور غير متطابقة")]
        public string ConfirmPassword { get; set; }
    }
}
