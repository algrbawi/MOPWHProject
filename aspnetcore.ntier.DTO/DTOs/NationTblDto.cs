using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class NationTblDto
    {
        public decimal NationId { get; set; }

        public decimal? NationCode { get; set; }

        public string? NationName { get; set; }

        public bool? NationState { get; set; }

        public decimal? SiteId { get; set; }
    }
}
