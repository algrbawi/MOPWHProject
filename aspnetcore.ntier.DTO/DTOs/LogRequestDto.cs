using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class LogRequestDto
    {
        public DateTime RequestAt { get; set; }
        public string Body { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Error { get; set; }
        public string Schema { get; set; }
        public string HttpMethod { get; set; }
    }
}
