using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
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
        public async Task<IActionResult> AddSite(SiteTblDto model)
        {
            await _siteService.AddAsync(model);
            return Ok();
        }
    }
}
