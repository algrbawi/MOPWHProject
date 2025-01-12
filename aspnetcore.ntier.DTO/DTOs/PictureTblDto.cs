using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class PictureTblDto
    {
        public decimal PicId { get; set; }

        public DateOnly? PicDate { get; set; }

        public TimeOnly? PicTime { get; set; }

        public string? PicCamera { get; set; }

        public bool? PicState { get; set; }

        public string? PicImage { get; set; }

        public string? PicTruckId { get; set; }

        public decimal? SiteId { get; set; }
    }
}
