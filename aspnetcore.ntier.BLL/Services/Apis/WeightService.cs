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


        public async Task<WeightReportDto> GetWeightReportData(int SiteId, DateOnly Date, ReportType ReportType, string userEmail)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email.ToLower() == userEmail.ToLower());
            var date = GetFilterDate(ReportType, Date);
            var results = await _weightTblRepository.GetListAsync(
                                                                    x => x.SiteId == SiteId && x.InDate >= date.Item1 && x.InDate <= date.Item2 && (user.IsSuperAdmin || x.Site.AccessUsers.Any(x => x.Id == user.Id)),
                                                                    include: x => x.Include(n => n.Nation)
                                                                                    .Include(p => p.Product)
                                                                                    .Include(d => d.Driver)
                                                                                    .Include(u => u.User)
                                                                                    .Include(s => s.Site)
                                                                                    .ThenInclude(uac => uac.AccessUsers));

            var weightReport = new WeightReportDto();
            return GetReportDataType(results, ReportType);

        }

        private string FixTimeFormat(TimeOnly? time)
        {
            if (time is not null)
            {
                return time.Value.ToString("HH:mm");
            }
            return null;
        }
        private (DateOnly, DateOnly) GetFilterDate(ReportType reportType, DateOnly date)
        {
            DateOnly filterDateFrom = DateOnly.FromDateTime(DateTime.Now);
            DateOnly filterDateTo = DateOnly.FromDateTime(DateTime.Now);

            if (reportType == ReportType.daily)
            {
                filterDateFrom = date;
                filterDateTo = date;
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
            if (reportType != ReportType.daily)
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
                    DateOnly = v.Key,
                    TotalNumberWeights = v.Count(),
                    TotalTruckesNotInViolation = v.Where(x => x.VioPrice == 0).Count(),
                    TotalTruckesViolation = v.Where(x => x.VioPrice > 0).Count(),
                    TotalTruckesViolationGreaterThan5 = v.Where(v => v.VioWeight >= 6000 && v.VioPrice > 0).Count(),
                    TotalTruckesViolationLessThan5 = v.Where(v => v.VioWeight < 6000 && v.VioPrice > 0).Count(),
                    TotalViolationWeights = v.Where(x => x.VioPrice > 0).Sum(x => x.VioWeight),
                    TotalViolationPrice = v.Where(x => x.VioPrice > 0).Sum(x => x.VioPrice)
                }).ToList();

            }

            else
            {
                weightReportDto.ReportData = weightTbls.OrderBy(x => x.InDate == null).ThenBy(x => x.InDate).Select((v, i) => new ReportData
                {
                    Number = i + 1,
                    OperationNumber = v.WId,
                    DateOnly = v.InDate,
                    TimeOnly = FixTimeFormat(v.InTime),
                    TruckNumber = v.TruckNum,
                    Nationality = v.Nation?.NationName,
                    Classification = v.SeqNo,
                    TruckWeiht = v.TruckWeight,
                    AllowedWeight = v.ClassWeight,
                    DiifWeight = v.DiffWeight,
                    Violation = v.VioPrice,
                    ProductName = v.Product?.ProductName,
                    DriverName = v.Driver?.DriverName,
                    UserName = v.User?.UserName,

                }).ToList();
            }

            weightReportDto.TotalViolationTrucks = weightTbls.Where(v => v.VioPrice > 0).Count();
            weightReportDto.TotalTrucks = weightTbls.Count();
            weightReportDto.TotalViolationWeight = weightTbls.Where(v => v.VioPrice > 0).Sum(x => x.VioWeight).Value;
            weightReportDto.TotlaViolationPrice = weightTbls.Where(v => v.VioPrice > 0).Sum(x => x.VioPrice).Value;
            weightReportDto.TotlaViolationNumberMoreThan5 = weightTbls.Where(v => v.VioWeight >= 6000 && v.VioPrice > 0).Count();
            return weightReportDto;
        }
    }
}
