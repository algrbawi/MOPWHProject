using aspnetcore.ntier.BLL;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.PDF;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using SelectPdf;
using System.Diagnostics.Metrics;
using System.IO;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IWeightService _weightService;
        private readonly ISiteService _siteService;

        public ReportController(IWeightService weightService, ISiteService siteService)
        {
            _weightService = weightService;
            _siteService = siteService;
        }
        public async Task<IActionResult> ReportDetails(ReportDetailsRequestViewModel model)
        {
            if (model.SiteId == 0)
            {
                return RedirectToAction("index", "home");
            }

            var site = await GetSiteAsync(model.SiteId);
            var results = new ReportDetailsResponseViewModel();
            if (model.Date.HasValue && model.DateType.HasValue)
            {
                var filterDates = GetFilterDate(model.DateType.Value, model.Date.Value);

                var weightResults = await _weightService.GetWeightBySiteIdAsync(model.SiteId, filterDates.Item1, filterDates.Item2);

                if (!isTheUserSuperAdmin())
                {
                    if (!GetUserAccessToSites().Contains(model.SiteId))
                    {
                        site = new SiteTblDto();
                    }
                    var userAccess = GetUserAccessToSites();
                    weightResults = weightResults.Where(x => userAccess.Contains(x.SiteId.Value)).ToList();
                }
                results.Site = site;
                results.Weights = weightResults;
            }
            else
            {
                results.Site = site;
                results.Weights = new List<WeightTblDto>();

            }
            results.SiteId = model.SiteId;
            results.Date = model.Date;
            results.DateType = model.DateType;
            return View(results);
        }

        public async Task<IActionResult> DownloadReport(ReportDetailsRequestViewModel model)
        {
            var filterDates = GetFilterDate(model.DateType.Value, model.Date.Value);
            var weightResults = await _weightService.GetWeightBySiteIdAsync(model.SiteId, filterDates.Item1, filterDates.Item2);
            var site = await GetSiteAsync(model.SiteId);

            var pdfDto = new PdfDto
            {
                DateType = model.DateType.Value,
                SiteName = site.SiteName,
                SiteTitle = site.SiteTitle
            };
            if (model.DateType == DateType.daily)
            {
                pdfDto.MainTable = weightResults.Select((x, i) => new ReportMainContentDto
                {
                    Number = i + 1,
                    OperationNumber = x.WId,
                    DateOnly = x.InDate,
                    TimeOnly = FixTimeFormat(x.InTime),
                    TruckNumber = x.TruckNum,
                    Nationality = x.Nation?.NationName,
                    Classification = x.SeqNo,
                    TruckWeiht = x.TruckWeight,
                    AllowedWeight = x.ClassWeight,
                    DiifWeight = x.DiffWeight,
                    Violation = x.VioPrice,
                    ProductName = x.Product?.ProductName,
                    DriverName = x.Driver?.DriverName,
                    UserName = x.User?.UserName,
                }).ToList();

            }
            else if (model.DateType == DateType.monthly)
            {
                pdfDto.MainTable = weightResults.GroupBy(d => d.InDate?.Day).OrderBy(x => x.Key).Select((x, i) => new ReportMainContentDto
                {
                    Number = i + 1,
                    DateOnly = x.Key,
                    TotalNumberWeights = x.Count(),
                    TotalTruckesNotInViolation = x.Where(x => x.VioPrice == 0).Count(),
                    TotalTruckesViolation = x.Where(x => x.VioPrice > 0).Count(),
                    TotalTruckesViolationGreaterThan5 = x.Where(v => v.VioWeight >= 6000 && v.VioPrice > 0).Count(),
                    TotalTruckesViolationLessThan5 = x.Where(v => v.VioWeight < 6000 && v.VioPrice > 0).Count(),
                    TotalViolationWeights = x.Where(x => x.VioPrice > 0).Sum(x => x.VioWeight),
                    TotalViolationPrice = x.Where(x => x.VioPrice > 0).Sum(x => x.VioPrice)

                }
                ).ToList();
            }
            else
            {
                pdfDto.MainTable = weightResults.GroupBy(d => d.InDate?.Month).OrderBy(x => x.Key).Select((x, i) => new ReportMainContentDto
                {
                    Number = i + 1,
                    DateOnly = x.Key,
                    TotalNumberWeights = x.Count(),
                    TotalTruckesNotInViolation = x.Where(x => x.VioPrice == 0).Count(),
                    TotalTruckesViolation = x.Where(x => x.VioPrice > 0).Count(),
                    TotalTruckesViolationGreaterThan5 = x.Where(v => v.VioWeight >= 6000 && v.VioPrice > 0).Count(),
                    TotalTruckesViolationLessThan5 = x.Where(v => v.VioWeight < 6000 && v.VioPrice > 0).Count(),
                    TotalViolationWeights = x.Where(x => x.VioPrice > 0).Sum(x => x.VioWeight),
                    TotalViolationPrice = x.Where(x => x.VioPrice > 0).Sum(x => x.VioPrice)

                }
            ).ToList();
            }
            PDFService pDFService = new PDFService(pdfDto);


            pdfDto.HeaderTable = new ReportHeaderContentDto
            {

                TotalTrucks = weightResults.Count(),
                TotalViolationTrucks = weightResults.Where(v => v.VioPrice > 0).Count(),
                TotalViolationWeight = weightResults.Where(v => v.VioPrice > 0).Sum(x => x.VioWeight),
                TotlaViolationPrice = weightResults.Where(v => v.VioPrice > 0).Sum(x => x.VioPrice),
                TotlaViolationNumberMoreThan5 = weightResults.Where(v => v.VioWeight >= 6000 && v.VioPrice > 0).Count()
            };
            var reportPdf = pDFService.GeneratePdf();
            return File(reportPdf, "application/octet-stream", model.DateType.ToString() + ".pdf");
        }

        private (DateOnly, DateOnly) GetFilterDate(DateType dateType, DateOnly date)
        {
            DateOnly filterDateFrom = DateOnly.FromDateTime(DateTime.Now);
            DateOnly filterDateTo = DateOnly.FromDateTime(DateTime.Now);

            if (dateType == DateType.daily)
            {
                filterDateFrom = date;
                filterDateTo = date;
            }
            else if (dateType == DateType.monthly)
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

        private bool isTheUserSuperAdmin()
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role && x.Value == "SuperAdmin");
            return role is not null ? true : false;
        }
        private List<decimal> GetUserAccessToSites()
        {
            var role = User.Claims.Where(x => x.Type == ClaimTypes.Role && decimal.TryParse(x.Value, out _) == true).Select(x => Convert.ToDecimal(x.Value)).ToList();
            return role;
        }

        private async Task<SiteTblDto> GetSiteAsync(int siteId)
        {
            var site = await _siteService.GetAsync(siteId);
            if (!isTheUserSuperAdmin())
            {
                if (!GetUserAccessToSites().Contains(site.SiteId))
                {
                    site = new SiteTblDto();
                }
            }
            return site;
        }
        private string FixTimeFormat(TimeOnly? time)
        {
            if (time is not null)
            {
                return time.Value.ToString("HH:mm");
            }
            return null;
        }
    }
}
