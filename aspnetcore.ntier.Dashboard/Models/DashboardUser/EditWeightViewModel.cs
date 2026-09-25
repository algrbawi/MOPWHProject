using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class EditWeightViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال رقم الوزن")]
        public decimal? WId { get; set; }
        [Required(ErrorMessage = "يرجى إدخال رقم الوصل")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "يُسمح فقط بالأحرف والأرقام.")]
        public string? Bill_Num { get; set; }
        [Required(ErrorMessage = "يرجى إدخال رقم الضبط")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "يُسمح فقط بالأحرف والأرقام.")]
        public string? Vio_Num { get; set; }
        [Required(ErrorMessage = "يرجى إدخال إسم دافع الفاتورة")]
        [RegularExpression(@"^[A-Za-z\u0600-\u06FF0-9 ]+$", ErrorMessage = "يُسمح فقط بالأحرف والأرقام والمسافات.")]
        public string? Bill_Name { get; set; }
        public int SiteId { get; set; }
    }
}
