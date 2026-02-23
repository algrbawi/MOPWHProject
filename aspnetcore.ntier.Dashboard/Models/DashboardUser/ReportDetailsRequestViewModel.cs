using aspnetcore.ntier.DTO.Enum;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string ReportTypeText
        {
            get
            {
                switch (ReportType)
                {
                    case DTO.Enum.ReportType.daily:
                        return "يومي";
                        break;
                    case DTO.Enum.ReportType.monthly:
                        return "شهري";
                        break;
                    case DTO.Enum.ReportType.yearly:
                        return "سنوي";
                        break;
                    case DTO.Enum.ReportType.bill:
                        return "نقرير وصولات المخالفات";
                        break;
                    case DTO.Enum.ReportType.vehicle:
                        return "تقرير حسب المركبة";
                        break;
                    case DTO.Enum.ReportType.violation_vehicle:
                        return "تقرير المركبات المخالفة";
                        break;
                    default:
                        return "";
                        break;
                }
                return "";
            }
        }
    }
}
