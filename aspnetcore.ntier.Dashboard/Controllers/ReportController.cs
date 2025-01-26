using aspnetcore.ntier.BLL;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Security.Claims;

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

        public IActionResult GenerateReportAsHTML()
        {
            return View();
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
    }
}
