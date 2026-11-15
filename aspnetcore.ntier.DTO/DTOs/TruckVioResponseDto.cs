using System;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class TruckVioResponseDto
    {
        public decimal WId { get; set; }
        public DateOnly? InDate { get; set; }
        public TimeOnly? InTime { get; set; }
        public int? ClassWeight { get; set; }
        public int? TruckWeight { get; set; }
        public int? DiffWeight { get; set; }
        public decimal? VioPrice { get; set; }
        public int? VioWeight { get; set; }
        public string TruckNum { get; set; }
        public string DriverName { get; set; }
        public decimal? SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteLocation { get; set; }
        public string SiteTitle { get; set; }
    }
}
