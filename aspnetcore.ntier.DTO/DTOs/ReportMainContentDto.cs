using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class ReportMainContentDto
    {
        public object? Number { get; set; }
        public object? OperationNumber { get; set; }
        public object? DateOnly { get; set; }
        public object? TimeOnly { get; set; }
        public object? TruckNumber { get; set; }
        public object? Nationality { get; set; }
        public object? Classification { get; set; }
        public object? TruckWeiht { get; set; }
        public object? AllowedWeight { get; set; }
        public object? DiifWeight { get; set; }
        public object? Violation { get; set; }
        public object? ProductName { get; set; }
        public object? DriverName { get; set; }
        public object? UserName { get; set; }
        public object? TotalNumberWeights { get; set; }
        public object? TotalTruckesNotInViolation { get; set; }
        public object? TotalTruckesViolation { get; set; }
        public object? TotalTruckesViolationGreaterThan5 { get; set; }
        public object? TotalTruckesViolationLessThan5 { get; set; }
        public object? TotalViolationWeights { get; set; }
        public object? TotalViolationPrice { get; set; }
    }
}
