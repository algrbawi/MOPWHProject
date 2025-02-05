using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class AddEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يرجى إدخال البريد الألكتروني")]
        [RegularExpression(pattern: @"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "صيغة البريد الألكتروني غير صحيحة")]
        public string Email { get; set; }
        [Required(ErrorMessage = "يرجى إدخال الأسم")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يرجى إدخال كلمة المرور")]
        [MinLength(6, ErrorMessage = "كلمة المرور يجب ان تحتوي على الالقل 6 أحرف ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "يرجى تحديد نوع المستخدم")]
        public bool IsSuperAdmin { get; set; } = true;
        public bool IsAllowedToEdit { get; set; } = false;
        public List<decimal>? SitePermissions { get; set; }

        public List<SelectListItem> SiteItems { get; set; } = new List<SelectListItem>();
    }
}
