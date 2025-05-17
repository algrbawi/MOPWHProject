using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class LogTblDto
    {
        public decimal LogId { get; set; }

        public decimal? LogCode { get; set; }

        public string? LogName { get; set; }

        public DateOnly? LogDate { get; set; }

        public TimeOnly? LogTime { get; set; }

        public string? LogTrans { get; set; }

        public decimal? UserId { get; set; }

        public decimal? SiteId { get; set; }
    }
}
