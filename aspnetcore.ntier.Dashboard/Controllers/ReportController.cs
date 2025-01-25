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
        public async Task<IActionResult> Index(int SiteId)
        {
            if (SiteId == 0)
            {
                return RedirectToAction("index", "home");
            }
            var site = await _siteService.GetAsync(SiteId);
            if (!isTheUserSuperAdmin())
            {
                if (!GetUserAccessToSites().Contains(site.SiteId))
                {
                    site = new SiteTblDto();
                }
            }
            var model = new IndexReportViewModel
            {
                Site = site,
                Weights = new List<WeightTblDto>()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> GetReportResult(IndexReportViewModel model)
        {

            var filterDates = GetFilterDate(model.DateType, model.Date);
            var site = await _siteService.GetAsync(model.SiteId);
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

            var results = new IndexReportViewModel
            {
                Site = site,
                Weights = weightResults
            };
            return View("index", results);
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
                filterDateFrom = date;
                filterDateTo = date.AddMonths(1);
            }
            else
            {
                filterDateFrom = date;
                filterDateTo = date.AddYears(1);
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
    }
}
