using aspnetcore.ntier.DTO.Enum;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsRequestViewModel
    {
        public int SiteId { get; set; }
        public DateOnly? SearchDate { get; set; }
        public ReportType? ReportType { get; set; }
    }
}
