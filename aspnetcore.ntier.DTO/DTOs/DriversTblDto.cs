using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class DriversTblDto
    {
        public decimal DriverId { get; set; }

        public decimal? DriverCode { get; set; }

        public string? DriverName { get; set; }

        public bool? DriverState { get; set; }

        public decimal? SiteId { get; set; }
    }
}
