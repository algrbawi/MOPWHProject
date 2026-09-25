using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class AddEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يرجى إدخال اسم المستخدم")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "يرجى إدخال بريد إلكتروني صحيح.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "يرجى إدخال الأسم")]
        [RegularExpression(@"^[A-Za-z\u0600-\u06FF0-9 ]+$", ErrorMessage = "يُسمح فقط بالأحرف والأرقام والمسافات.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يرجى إدخال كلمة المرور")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,16}$",
        ErrorMessage = "يجب أن تكون كلمة المرور بين 8 إلى 16 حرفًا، وتحتوي على حرف كبير واحد على الأقل، وحرف صغير واحد على الأقل، ورقم واحد على الأقل، وحرف خاص واحد على الأقل")]
        public string Password { get; set; }
        [Required(ErrorMessage = "يرجى تحديد نوع المستخدم")]
        public bool IsSuperAdmin { get; set; } = true;
        public bool IsAllowedToEdit { get; set; } = false;
        public List<decimal>? SitePermissions { get; set; }

        public bool IsActive { get; set; }

        public List<SelectListItem> SiteItems { get; set; } = new List<SelectListItem>();
    }
}
