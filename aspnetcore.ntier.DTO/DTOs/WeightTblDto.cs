using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class WeightTblDto
    {
        public decimal WId { get; set; }
        public decimal? SeqNo { get; set; }
        public DateOnly? InDate { get; set; }
        public TimeOnly? InTime { get; set; }

        public decimal? WClassId { get; set; }

        public int? ClassWeight { get; set; }

        public int? TruckWeight { get; set; }

        public int? DiffWeight { get; set; }

        public decimal? VioPrice { get; set; }

        public int? VioWeight { get; set; }

        public string? TruckNum { get; set; }

        public decimal? NationId { get; set; }

        public decimal? ProductId { get; set; }

        public decimal? DriverId { get; set; }

        public bool? Printed { get; set; }

        public bool? Transed { get; set; }

        public string? WeightS { get; set; }

        public bool? WeightLocation { get; set; }

        public string? WeightNote { get; set; }

        public bool? WeightState { get; set; }

        public decimal? UserId { get; set; }
        public string? Bill_Num { get; set; }
        public string? Vio_Num { get; set; }
        public string? Bill_Name { get; set; }

        public decimal? SiteId { get; set; }

        public NationTblDto? Nation { get; set; }
        public ProductsTblDto? Product { get; set; }
        public DriversTblDto? Driver { get; set; }
        public UsersTblDto? User { get; set; }
    }
}
