using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class UsersTblDto
    {
        public decimal UserId { get; set; }

        public decimal? UserCode { get; set; }

        public string? UserName { get; set; }

        public string? UserPassword { get; set; }

        public string? UserType { get; set; }

        public bool? UserState { get; set; }

        public decimal? SiteId { get; set; }
    }
}
