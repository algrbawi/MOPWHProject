using aspnetcore.ntier.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class PdfDto
    {
        public int TotalTrucks { get; set; }
        public int TotalViolationTrucks { get; set; }
        public int TotalViolationWeight { get; set; }
        public decimal TotlaViolationPrice { get; set; }
        public int TotlaViolationNumberMoreThan5 { get; set; }
        public string SiteName { get; set; }
        public string SiteTitle { get; set; }
        public ReportType reportType { get; set; }
        public string ReportTypeText
        {
            get
            {
                return this.reportType switch
                {
                    ReportType.daily => "يومي",
                    ReportType.monthly => "شهري",
                    ReportType.bill => "تقرير وصولات المخالفات",
                    _ => "سنوي",

                };

            }
        }
        public List<ReportData> ReportData { get; set; }
    }
}
