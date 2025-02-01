using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class EditWeightViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال رقم الوزن")]
        public decimal? WId { get; set; }
        [Range(0 , double.MaxValue , ErrorMessage ="القيمة المدخلة غير صحيحة")]
        public int? ClassWeight { get; set; }
        public int SiteId { get; set; }
    }
}
