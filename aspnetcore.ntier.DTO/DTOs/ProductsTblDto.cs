using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class ProductsTblDto
    {
        public decimal ProductId { get; set; }

        public decimal? ProductCode { get; set; }

        public string? ProductName { get; set; }

        public string? ProductLocation { get; set; }

        public bool? ProductState { get; set; }

        public decimal? SiteId { get; set; }
    }
}
