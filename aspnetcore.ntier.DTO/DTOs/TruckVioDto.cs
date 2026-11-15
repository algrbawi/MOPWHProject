using System;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class TruckVioDto
    {
        public string TruckNum { get; set; }
        public string SiteName { get; set; }
        public int? TruckWeight { get; set; }
        public int? WClassWeight { get; set; }
        public int? WClassAxles { get; set; }
        public int? VioWeight { get; set; }
        public decimal? VioPrice { get; set; }
        public DateOnly? ViolationDate { get; set; }
        public TimeOnly? ViolationTime { get; set; }
    }
}
