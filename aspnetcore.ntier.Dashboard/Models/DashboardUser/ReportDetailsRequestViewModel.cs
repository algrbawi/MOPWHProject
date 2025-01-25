namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsRequestViewModel
    {
        public int SiteId { get; set; }
        public DateOnly? Date { get; set; }
        public DateType? DateType { get; set; }
    }
}
