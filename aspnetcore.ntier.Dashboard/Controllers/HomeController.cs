using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISiteService _siteService;
        public HomeController(ILogger<HomeController> logger, ISiteService siteService)
        {
            _logger = logger;
            _siteService = siteService;
        }

        public async Task<IActionResult> Index(string siteName = "")
        {
            ViewBag.IsSubSite = false;
            var results = await _siteService.GetUserSitesListAsync(User.Identity.Name, siteName);
            if (!string.IsNullOrEmpty(siteName))
            {
                results = results.GroupBy(x => x.SiteName).Select(x => x.First()).ToList();
                ViewBag.IsSubSite = true;
            }
            return View(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return RedirectToAction("login", "account");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
