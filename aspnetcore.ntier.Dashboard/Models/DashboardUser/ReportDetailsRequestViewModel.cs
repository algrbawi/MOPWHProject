using aspnetcore.ntier.DTO.Enum;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsRequestViewModel
    {
        private string? PrivateTruckNumber;
        private string? PrivateProduct;
        private string PrivateClassfication;
        public int SiteId { get; set; }
        public DateOnly? SearchDate { get; set; }
        public DateOnly? SearchDateTo { get; set; }
        public string? TruckNumber
        {
            get { return (ReportType != null && (ReportType == DTO.Enum.ReportType.bill || ReportType == DTO.Enum.ReportType.vehicle)) ? PrivateTruckNumber : null; }
            set { PrivateTruckNumber = value; }
        }
        public string? Product
        {
            get { return (ReportType != null && ReportType == DTO.Enum.ReportType.vehicle || ReportType == DTO.Enum.ReportType.violation_vehicle) ? PrivateProduct : null; }
            set { PrivateProduct = value; }
        }

        public string Classfication
        {
            get { return (ReportType != null && ReportType == DTO.Enum.ReportType.vehicle || ReportType == DTO.Enum.ReportType.violation_vehicle) ? PrivateClassfication : null; }
            set { PrivateClassfication = value; }
        }

        public ReportType? ReportType { get; set; }
    }
}
