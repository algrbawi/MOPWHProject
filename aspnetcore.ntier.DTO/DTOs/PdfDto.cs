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
        public ReportHeaderContentDto HeaderTable { get; set; }
        public List<ReportMainContentDto> MainTable { get; set; }
        public ReportType DateType { get; set; }
        public string SiteName { get; set; }
        public string SiteTitle { get; set; }

        public string ReportDateType
        {
            get
            {
                return this.DateType switch
                {
                    ReportType.daily => "يومي",
                    ReportType.monthly => "شهري",
                    _ => "سنوي"
                };
            }
        }



    }
}
