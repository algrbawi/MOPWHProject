using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class TrucksTblDto
    {
        public decimal TruckId { get; set; }

        public decimal? TruckCode { get; set; }

        public string TruckNum { get; set; } = null!;

        public bool? TruckState { get; set; }

        public decimal? SiteId { get; set; }
    }
}
