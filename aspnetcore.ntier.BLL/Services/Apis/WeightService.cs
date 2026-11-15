using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.BLL.Services.Apis
{
    public class WeightService : IWeightService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<WeightTbl> _weightTblRepository;
        private readonly IGenericRepository<DashboardUser> _dashboardUserRepository;



        public WeightService(IMapper mapper, IGenericRepository<WeightTbl> weightTblRepository, IGenericRepository<DashboardUser> dashboardUserRepository)
        {
            _mapper = mapper;
            _weightTblRepository = weightTblRepository;
            _dashboardUserRepository = dashboardUserRepository;
        }

        public async Task AddAsync(WeightTblDto model)
        {
            var weightTbl = _mapper.Map<WeightTbl>(model);
            await _weightTblRepository.AddAsync(weightTbl);
        }

        public async Task<List<WeightTblDto>> GetWeightBySiteIdAsync(int SiteId, DateOnly From, DateOnly To)
        {

            var results = await _weightTblRepository.GetListAsync(
                x => x.SiteId == SiteId && x.InDate >= From && x.InDate <= To,
                include: x => x.Include(n => n.Nation).Include(p => p.Product).Include(d => d.Driver).Include(u => u.User));

            return _mapper.Map<List<WeightTblDto>>(results);
        }
        public async Task<WeightTblDto> GetBySiteIdAsync(int SiteId, decimal WID, string email)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email == email);
            var results = await _weightTblRepository.GetAsync(
                x => x.SiteId == SiteId && x.WId == WID && (user.IsSuperAdmin || x.Site.AccessUsers.Any(x => x.DashboardUserId == user.Id)), include: inc => inc.Include(x => x.Site).ThenInclude(x => x.AccessUsers).ThenInclude(ds => ds.DashboardUser));
            return _mapper.Map<WeightTblDto>(results);
        }

        public async Task UpdateAsync(EditWeightTblDto model)
        {
            var weight = await _weightTblRepository.GetAsync(x => x.WId == model.WID);
            weight.Vio_Num = model.Vio_Num;
            weight.Bill_Name = model.Bill_Name;
            weight.Bill_Num = model.Bill_Num;
            await _weightTblRepository.UpdateAsync(weight);
        }


        public async Task<WeightReportDto> GetWeightReportData(int SiteId, DateOnly Date, ReportType ReportType, string userEmail, DateOnly? ToDate = null, string? TruckNumber = null, string? Product = null, string? classification = null)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email.ToLower() == userEmail.ToLower());
            var date = GetFilterDate(ReportType, Date, ToDate);
            var results = await _weightTblRepository.GetListAsync(
                                                                    x => x.SiteId == SiteId &&
                                                                    x.InDate >= date.Item1 && x.InDate <= date.Item2 &&
                                                                    (user.IsSuperAdmin || x.Site.AccessUsers.Any(x => x.DashboardUserId == user.Id)) &&
                                                                    (string.IsNullOrEmpty(TruckNumber) ? true : x.TruckNum == TruckNumber)
                                                                    &&
                                                                    (string.IsNullOrEmpty(classification) ? true : x.WClass.WClassName == classification)
                                                                    &&
                                                                    (string.IsNullOrEmpty(Product) ? true : x.Product.ProductName == Product)
                                                                    &&
                                                                    (ReportType != ReportType.bill ? true : x.VioPrice > 0 && !string.IsNullOrEmpty(x.Bill_Name) && !string.IsNullOrEmpty(x.Bill_Num) && !string.IsNullOrEmpty(x.Vio_Num)),
                                                                    include: x => x.Include(n => n.Nation)
                                                                                    .Include(p => p.Product)
                                                                                    .Include(d => d.Driver)
                                                                                    .Include(u => u.User)
                                                                                    .Include(c => c.WClass)
                                                                                    .Include(s => s.Site)
                                                                                    .ThenInclude(uac => uac.AccessUsers));

            var weightReport = new WeightReportDto();
            return GetReportDataType(results, ReportType);

        }

        public async Task<WeightReportDto> GetWeightReportData(int SiteId, decimal WId, string userEmail)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email.ToLower() == userEmail.ToLower());
            var results = await _weightTblRepository.GetListAsync(
                                                                    x => x.SiteId == SiteId && x.WId == WId && (user.IsSuperAdmin || x.Site.AccessUsers.Any(x => x.Id == user.Id)),

                                                                    include: x => x.Include(n => n.Nation)
                                                                                    .Include(p => p.Product)
                                                                                    .Include(d => d.Driver)
                                                                                    .Include(u => u.User)
                                                                                    .Include(s => s.Site)
                                                                                    .ThenInclude(uac => uac.AccessUsers));

            var weightReport = new WeightReportDto();
            return GetReportDataType(results, ReportType.bill);

        }

        public async Task<List<WeightTblDto>> GetTruckVioAsync(string userEmail, string truckNum, DateOnly? date = null, decimal? siteId = null)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email.ToLower() == userEmail.ToLower());
            if (user == null)
            {
                return new List<WeightTblDto>();
            }

            var cleanTruckNum = truckNum?.Trim();
            if (string.IsNullOrEmpty(cleanTruckNum))
            {
                return new List<WeightTblDto>();
            }

            var results = await _weightTblRepository.GetListAsync(
                x => x.VioPrice > 0 && x.VioWeight > 0 &&
                     x.TruckNum == cleanTruckNum &&
                     (date == null || x.InDate == date) &&
                     (siteId == null || x.SiteId == siteId) &&
                     (user.IsSuperAdmin || (x.Site != null && x.Site.AccessUsers.Any(a => a.DashboardUserId == user.Id))),
                include: x => x.Include(c => c.WClass)
                                .Include(s => s.Site));

            return _mapper.Map<List<WeightTblDto>>(results.OrderByDescending(x => x.InDate).ThenByDescending(x => x.InTime).ToList());
        }

        private string FixTimeFormat(TimeOnly? time)
        {
            if (time is not null)
            {
                return time.Value.ToString("HH:mm");
            }
            return null;
        }
        private (DateOnly, DateOnly) GetFilterDate(ReportType reportType, DateOnly date, DateOnly? toDate)
        {
            DateOnly filterDateFrom = DateOnly.FromDateTime(DateTime.Now);
            DateOnly filterDateTo = DateOnly.FromDateTime(DateTime.Now);

            if (reportType == ReportType.daily)
            {
                filterDateFrom = date;
                filterDateTo = date;
            }
            else if (reportType == ReportType.bill || reportType == ReportType.vehicle || reportType == ReportType.violation_vehicle)
            {
                filterDateFrom = date;
                if (toDate is null)
                {
                    toDate = date;
                }
                filterDateTo = toDate.Value;
            }
            else if (reportType == ReportType.monthly)
            {
                filterDateFrom = new DateOnly(date.Year, date.Month, 1);
                filterDateTo = filterDateFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                filterDateFrom = new DateOnly(date.Year, 1, 1);
                filterDateTo = filterDateFrom.AddYears(1).AddDays(-1);
            }
            return (filterDateFrom, filterDateTo);

        }

        private WeightReportDto GetReportDataType(List<WeightTbl> weightTbls, ReportType reportType)
        {
            IEnumerable<IGrouping<int?, WeightTbl>> weights = null;
            var weightReportDto = new WeightReportDto();
            if (reportType == ReportType.daily || reportType == ReportType.bill || reportType == ReportType.vehicle || reportType == ReportType.violation_vehicle)
            {

                weightReportDto.ReportData = weightTbls.OrderBy(x => x.InDate == null).ThenBy(x => x.InDate).Select((v, i) => new ReportData
                {
                    Number = i + 1,
                    OperationNumber = v.WId,
                    DateOnly = v.InDate is null ? null : v.InDate.Value.ToString("dd/MM/yyyy"),
                    TimeOnly = FixTimeFormat(v.InTime),
                    TruckNumber = v.TruckNum,
                    Nationality = v.Nation?.NationName,
                    Classification = v.WClass?.WClassName,
                    TruckWeiht = v.TruckWeight,
                    AllowedWeight = v.ClassWeight,
                    DiifWeight = v.DiffWeight,
                    Violation = v.VioPrice,
                    ProductName = v.Product?.ProductName,
                    DriverName = v.Driver?.DriverName,
                    UserName = v.User?.UserName,
                    Bill_Name = v.Bill_Name,
                    Bill_Num = v.Bill_Num,
                    Vio_Num = v.Vio_Num,
                    WeightNote = v.WeightNote,

                }).ToList();

            }

            else
            {
                if (reportType == ReportType.monthly)
                {
                    weights = weightTbls.GroupBy(x => x.InDate?.Day);
                }
                else
                {
                    weights = weightTbls.GroupBy(x => x.InDate?.Month);
                }

                weightReportDto.ReportData = weights.OrderBy(x => x.Key).Select((v, i) => new ReportData
                {
                    Number = i + 1,
                    DateOnly = v.Key,
                    TotalNumberWeights = v.Count(),
                    TotalTruckesNotInViolation = v.Where(x => x.VioPrice == 0).Count(),
                    TotalTruckesViolation = v.Where(x => x.VioPrice > 0).Count(),
                    TotalTruckesViolationGreaterThan5 = v.Where(v => v.VioWeight >= 6 && v.VioPrice > 0).Count(),
                    TotalTruckesViolationLessThan5 = v.Where(v => v.VioWeight < 6 && v.VioPrice > 0).Count(),
                    TotalViolationWeights = v.Where(x => x.VioPrice > 0).Sum(x => x.VioWeight),
                    TotalViolationPrice = v.Where(x => x.VioPrice > 0).Sum(x => x.VioPrice),
                }).ToList();
            }

            weightReportDto.TotalViolationTrucks = weightTbls.Where(v => v.VioPrice > 0).Count();
            weightReportDto.TotalTrucks = weightTbls.Count();
            weightReportDto.TotalViolationWeight = weightTbls.Where(v => v.VioPrice > 0).Sum(x => x.VioWeight).Value;
            weightReportDto.TotlaViolationPrice = weightTbls.Where(v => v.VioPrice > 0).Sum(x => x.VioPrice).Value;
            weightReportDto.TotlaViolationNumberMoreThan5 = weightTbls.Where(v => v.VioWeight >= 6 && v.VioPrice > 0).Count();
            return weightReportDto;
        }
    }
}
