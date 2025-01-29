using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsResponseViewModel
    {
        public WeightReportDto ReportData { get; set; }
        public SiteTblDto Site { get; set; }
        public int SiteId { get; set; }
        public DateOnly? SearchDate { get; set; }
        public ReportType? ReportType { get; set; }
        public string DateTypeText
        {
            get
            {
                return this.ReportType switch
                {

                    DTO.Enum.ReportType.daily => "يومي",
                    DTO.Enum.ReportType.monthly => "شهري",
                    DTO.Enum.ReportType.yearly => "سنوي",
                    _ => ""
                };

            }
        }
    }
}
