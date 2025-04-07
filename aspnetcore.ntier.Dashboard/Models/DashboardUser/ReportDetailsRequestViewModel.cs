using aspnetcore.ntier.DTO.Enum;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsRequestViewModel
    {
        private string? PrivateTruckNumber;
        public int SiteId { get; set; }
        public DateOnly? SearchDate { get; set; }
        public DateOnly? SearchDateTo { get; set; }
        public string? TruckNumber
        {
            get { return (ReportType != null && (ReportType == DTO.Enum.ReportType.bill || ReportType == DTO.Enum.ReportType.vehicle)) ? PrivateTruckNumber : null; }
            set { PrivateTruckNumber = value; }
        }
        public ReportType? ReportType { get; set; }
    }
}
