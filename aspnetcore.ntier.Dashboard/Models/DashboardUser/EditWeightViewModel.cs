using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class EditWeightViewModel
    {
        [Required(ErrorMessage = "يرجى إدخال رقم الوزن")]
        [MaxLength(18, ErrorMessage = "")]
        public decimal? WId { get; set; }
        public string? Bill_Num { get; set; }
        public string? Vio_Num { get; set; }
        public string? Bill_Name { get; set; }
        public int SiteId { get; set; }
    }
}
