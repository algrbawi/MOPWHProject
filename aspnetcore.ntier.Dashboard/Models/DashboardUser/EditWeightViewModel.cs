using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class EditWeightViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال رقم الوزن")]
        public decimal? WId { get; set; }
        [Required(ErrorMessage = "يرجى إدخال رقم الوصل")]
        public string? Bill_Num { get; set; }
        [Required(ErrorMessage = "يرجى إدخال إسم دافع الفاتورة")]
        public string? Vio_Num { get; set; }
        [Required(ErrorMessage = "يرجى إدخال رقم الضبط")]
        public string? Bill_Name { get; set; }
        public int SiteId { get; set; }
    }
}
