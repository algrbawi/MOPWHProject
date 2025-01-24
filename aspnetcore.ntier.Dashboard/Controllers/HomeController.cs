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
            var isSuperAdmin = isTheUserSuperAdmin();
            var sites = new List<SiteTblDto>();
            if (isSuperAdmin)
            {
                sites = await _siteService.GetListAsync();
            }
            var results = new List<SiteTblDto>();
            if (!string.IsNullOrEmpty(siteName))
            {
                results = sites.Where(s => s.SiteName.ToLower() == siteName.ToLower()).ToList();
            }
            else
            {
                results = sites.GroupBy(x => x.SiteName).Select(x => x.First()).ToList();
            }
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool isTheUserSuperAdmin()
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role && x.Value == "SuperAdmin");
            return role is not null ? true : false;
        }
    }
}
