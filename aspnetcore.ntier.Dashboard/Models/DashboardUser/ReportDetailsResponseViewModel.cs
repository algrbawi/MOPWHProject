using aspnetcore.ntier.DTO.DTOs;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsResponseViewModel
    {
        public List<WeightTblDto> Weights { get; set; }
        public SiteTblDto Site { get; set; }
        public int SiteId { get; set; }
        public DateOnly? Date { get; set; }
        public DateType? DateType { get; set; }
    }
    public enum DateType
    {

        daily, monthly, yearly
    }
}
