using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.Dashboard.Models.Api;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{
    public class SiteController : BaseApiController
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [HttpPost("AddSite")]
        public async Task<IActionResult> AddSite(SiteRequestViewmodel model)
        {

            await _siteService.AddAsync(new SiteTblDto
            {
                SiteId = model.SiteId,
                SiteCode = model.SiteCode,
                SiteLocation = model.SiteLocation,
                SiteName = model.SiteName,
                SiteState = model.SiteState,
                SiteTitle = model.SiteTitle
            });
            return Ok();
        }
    }
}
