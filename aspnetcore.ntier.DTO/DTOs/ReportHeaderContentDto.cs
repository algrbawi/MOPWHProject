using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class ReportHeaderContentDto
    {
        public object TotalTrucks { get; set; }
        public object TotalViolationTrucks { get; set; }
        public object TotalViolationWeight { get; set; }
        public object TotlaViolationPrice { get; set; }
        public object TotlaViolationNumberMoreThan5 { get; set; }
    }
}
