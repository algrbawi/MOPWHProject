using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class SiteTblDto
    {
        public decimal SiteId { get; set; }

        public decimal? SiteCode { get; set; }

        public string? SiteName { get; set; }

        public string? SiteLocation { get; set; }

        public string? SiteTitle { get; set; }

        public bool? SiteState { get; set; }
    }
}
