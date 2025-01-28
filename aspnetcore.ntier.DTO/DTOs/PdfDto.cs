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
        public DateType DateType { get; set; }
        public string SiteName { get; set; }
        public string SiteTitle { get; set; }

        public string ReportDateType
        {
            get
            {
                return this.DateType switch
                {
                    DateType.daily => "يومي",
                    DateType.monthly => "شهري",
                    _ => "سنوي"
                };
            }
        }



    }
}
