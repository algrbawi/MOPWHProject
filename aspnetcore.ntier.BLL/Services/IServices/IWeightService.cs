using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface IWeightService
    {
        Task AddAsync(WeightTblDto model);
        Task<WeightTblDto> GetBySiteIdAsync(int SiteId, decimal WID, string email);
        Task<List<WeightTblDto>> GetWeightBySiteIdAsync(int SiteId, DateOnly From, DateOnly To);
        Task<WeightReportDto> GetWeightReportData(int SiteId, DateOnly Date, ReportType ReportType, string userEmail, DateOnly? ToDate = null, string? TruckNumber = null);
        Task<WeightReportDto> GetWeightReportData(int SiteId, decimal WId, string userEmail);
        Task UpdateAsync(EditWeightTblDto model);
    }
}
